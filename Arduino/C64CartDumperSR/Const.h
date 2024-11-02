/*  
  C64CartDumperSR.ino - C64 Cartridge Dumper
  Copyright (C) 2024 DrVector
  
  Dichiarazione costanti
*/

#include <Arduino.h>

//******************************************************************************************************************//
//* Pins pilota Shift Register 74HC595
//******************************************************************************************************************//
// Pin SER del SN74HC595
// Serial Data In - INPUT
const int SN_SER_PIN = 10;
// Pin SRCLK del SN74HC595
// Shift Register Clock - INPUT
const int SN_SRCLK_PIN = 12;
// Pin RCLK del SN74HC595
// Storage Register Clock - INPUT
const int SN_RCLK_PIN = 11;

//******************************************************************************************************************//
//* Pins C64 Cartridge
//******************************************************************************************************************//
// Pin /DMA del connettore C64
const int C64_DMA_PIN = A0;
// Pin /ROML del connettore C64
const int C64_ROML_PIN = A1;
// Pin /IO2 del connettore C64
const int C64_IO2_PIN = A2;
// Pin /EXROM del connettore C64
const int C64_EXROM_PIN = A3;
// Pin /GAME del connettore C64
const int C64_GAME_PIN = A4;
// Pin /IO1 del connettore C64
const int C64_IO1_PIN = A5;
// Pin /ROMH del connettore C64
const int C64_ROMH_PIN = 13;
