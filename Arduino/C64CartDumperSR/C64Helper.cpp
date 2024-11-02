/*  
  C64CartDumperSR.ino - Commodore 64 Cartridge Dumper
  Copyright (C) 2024 DrVector
  
  Helper funzioni di gestione bus dati e control pins della cartuccia
*/

#include <Arduino.h>
#include "Const.h"
#include "SRHelper.h"

//******************************************************************************************************************//
//* Abilita/Disabilita ROML
//******************************************************************************************************************//
void enableROML(bool enable) {
  if (enable) {
    digitalWrite(C64_ROML_PIN, LOW);
  }
  else {
    digitalWrite(C64_ROML_PIN, HIGH);
  }
}

//******************************************************************************************************************//
//* Abilita/Disabilita ROMH
//******************************************************************************************************************//
void enableROMH(bool enable) {
  if (enable) {
    digitalWrite(C64_ROMH_PIN, LOW);
  }
  else {
    digitalWrite(C64_ROMH_PIN, HIGH);
  }
}

//******************************************************************************************************************//
//* Lettura di un byte all'indirizzo selezionato dal bus dati della cartuccia
//******************************************************************************************************************//
byte readByte(unsigned int address) {
  // Imposta indirizzo
  addressWrite(address);

  // Lettura pins D2/D9 (Bus Dati)
  /*
  byte bval = 0;
  for (int y = 0; y < 8; y++) {
    bitWrite(bval, y, digitalRead(y + 2));
  }
  */
  byte pd = PIND;
  byte pb = PINB;

  //Serial.println("PIND=" + (String)pd);
  //Serial.println("PINB=" + (String)pb);

  byte bval = 0;
  bitWrite(bval, 0, bitRead(pd, 2));
  bitWrite(bval, 1, bitRead(pd, 3));
  bitWrite(bval, 2, bitRead(pd, 4));
  bitWrite(bval, 3, bitRead(pd, 5));
  bitWrite(bval, 4, bitRead(pd, 6));
  bitWrite(bval, 5, bitRead(pd, 7));
  bitWrite(bval, 6, bitRead(pb, 0));
  bitWrite(bval, 7, bitRead(pb, 1));

  // Serial.println("readByte=" + (String)bval);
  return bval;
}

//******************************************************************************************************************//
//* Dumping della ROM
//* Banco 0-1 LOW-HIGH
//******************************************************************************************************************//
void dumpROMBank(int bank) {
    // Serial.println("START DUMP BANK " + (String)bank);

    unsigned int addr = 0;
    
    // Seleziona il banco
    if (bank == 0) {
      enableROML(true);
      enableROMH(false);
    }
    else if (bank == 1) {
      enableROMH(true);
      enableROML(false);
    }

    // ROM 8 kB
    byte buffer[256];
    int index = 0;
    for (int i = 0; i <= 0x1FFF; i++) {  
      byte bval = readByte(addr + i);
      buffer[index] = bval;
      index ++;
      //Serial.println(bval, DEC);

      if (index == 256) {
        Serial.write(buffer, 256);
        index = 0;
      }
    }
    
    // Serial.println("END DUMP BANK " + (String)bank);
}
