/*  
  C64CartDumperSR.ino - Commodore 64 Cartridge Dumper
  Copyright (C) 2024 DrVector
  Utilizza 74HC595 shift registers
*/

#include <Arduino.h>
#include "Const.h"
#include "SRHelper.h"
#include "C64Helper.h"

//******************************************************************************************************************//
//* Variabili globali
//******************************************************************************************************************//
bool serialEcho = false;

//******************************************************************************************************************//
//* Setup
//******************************************************************************************************************//
void setup() {
  // Inizializza Ouput Pins per SN74HC595
  pinMode(SN_SRCLK_PIN, OUTPUT);
  pinMode(SN_SER_PIN, OUTPUT);
  pinMode(SN_RCLK_PIN, OUTPUT);

  // Inizializza Output Pins connettore C64
  pinMode(C64_ROML_PIN, OUTPUT);
  pinMode(C64_ROMH_PIN, OUTPUT); 
  // Imposta ROML attiva
  enableROML(true);
  enableROMH(false);

  // Inizializza Input Pins connettore C64
  pinMode(C64_DMA_PIN, INPUT);
  pinMode(C64_IO2_PIN, INPUT); 
  pinMode(C64_EXROM_PIN, INPUT); 
  pinMode(C64_GAME_PIN, INPUT); 
  pinMode(C64_IO1_PIN, INPUT); 

  // Imposta pin D2/D9 in INPUT
  for (int i = 2; i <= 9; i++) {
    pinMode(i, INPUT);
  }

  // Azzera lo shift register
  addressWrite(0x0000);

  //Serial.begin(115200);
  Serial.begin(500000);
  Serial.println("COMMODORE 64 CARTRIDGE DUMPER V.1.00");
  Serial.println("");
}

//******************************************************************************************************************//
//* Ciclo principale
//******************************************************************************************************************//
void loop() {
  // Lettura porta seriale
  String s = ReadSerialComand();

  // Parsing dei comandi
  ParseComands(s);
}

//******************************************************************************************************************//
//* Comandi
//******************************************************************************************************************//
// Parsing dei comandi
void ParseComands(String s) {
  String params[10];

  s.toUpperCase();
  if (s != "") {
    if (serialEcho) {
      Serial.println(s);
    }

    String comand = GetComand(s);
    // Serial.println("COMAND: " + comand);
    //**********************************************
    // ECHO
    //**********************************************
    if (comand == "ECHO") {
      GetComandParams(s, params);
      // Serial.println("PARAM: " + params[0]);
      if (params[0] == "1") {
        serialEcho = true;
      }
      else if (params[0] == "0") {
        serialEcho = false;
      }
      else if (params[0] == "?") {
        Serial.println("+ECHO=" + String(serialEcho));
      }
    }
    //**********************************************
    // VERSION
    //**********************************************
    if (comand == "VERSION") {
      GetComandParams(s, params);
      // Serial.println("PARAM: " + params[0]);
      if (params[0] == "?") {
        Serial.println("+VERSION=0.001b");
      }
    }
    //**********************************************
    // GETGAME
    //**********************************************
    if (comand == "GETGAME") {
      GetComandParams(s, params);
      //Serial.println("PARAM: " + params[0]);
      if (params[0] != "") {
        byte b = digitalRead(C64_GAME_PIN);
        Serial.println("+GETGAME=" + (String)b);
      }
    }
    //**********************************************
    // GETEXROM
    //**********************************************
    if (comand == "GETEXROM") {
      GetComandParams(s, params);
      //Serial.println("PARAM: " + params[0]);
      if (params[0] != "") {
        byte b = digitalRead(C64_EXROM_PIN);
        Serial.println("+GETEXROM=" + (String)b);
      }
    }
    //**********************************************
    // ROMH
    //**********************************************
    if (comand == "ROMH") {
      GetComandParams(s, params);
      if (params[0] == "0") {
        digitalWrite(C64_ROMH_PIN, LOW);
        Serial.println("+ROMH=0");
      }
      else if (params[0] == "1") {
        digitalWrite(C64_ROMH_PIN, HIGH);
        Serial.println("+ROMH=1");
      }
    }
    //**********************************************
    // ROML
    //**********************************************
    if (comand == "ROML") {
      GetComandParams(s, params);
      if (params[0] == "0") {
        digitalWrite(C64_ROML_PIN, LOW);
        Serial.println("+ROML=0");
      }
      else if (params[0] == "1") {
        digitalWrite(C64_ROML_PIN, HIGH);
        Serial.println("+ROML=1");
      }
    }
    //**********************************************
    // READBYTE
    //**********************************************
    if (comand == "READBYTE") {
      GetComandParams(s, params);
      //Serial.println("PARAM: " + params[0]);
      if (params[0] != "") {
        byte b = readByte(params[0].toInt());
        Serial.println("+READBYTE=" + (String)b);
      }
    }
    //**********************************************
    // DUMPROMBANK
    //**********************************************
    if (comand == "DUMPROMBANK") {
      GetComandParams(s, params);
      // Serial.println("PARAM: " + params[0]);
      if (params[0] != "") {
        dumpROMBank(params[0].toInt());
        //Serial.println("+++");
      }
    }
  }
}

// Ritorna la stringa di comando
String GetComand(String s) {
  String comand = "";

  int i = s.indexOf('=');
  return s.substring(0, i);
}

// Ritorna lista parametri
void GetComandParams(String s, String(&params)[10]) {
  int index = s.indexOf('=');
  String par = s;
  par.remove(0, index + 1);
  
  for (int i = 0; i < 10; i++) {
    index = par.indexOf(',');
    if (index == -1) {
      int l = par.length();
      if (l > 0) {
        params[i] = par;
      }
      return;
    }
    else {
      params[i] = par.substring(0, index);
    }
  }
}

//******************************************************************************************************************//
//* Lettura comandi su porta seriale
//******************************************************************************************************************//
// Variabili globali
char receivedChars[64] = "";
int rcIndex = 0;

String ReadSerialComand(){
  while (Serial.available()) {
    if (rcIndex > 63) rcIndex = 0;
    
    // Legge carattere dalla seriale
    char rc = Serial.read();
    // Carattere di fine comando
    if (rc == '\n' or rc == '\r') {
      receivedChars[rcIndex] = '\0';
      rcIndex = 0;
      return receivedChars;
    }
    else {
      // Nuovo carattere
      receivedChars[rcIndex] = rc;
      rcIndex++;
    }
  }
  
  return "";
}
