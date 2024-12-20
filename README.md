﻿# Commodore 64 Cartridge Dumper

Il progetto nasce in un contesto più ampio di conservazione della tecnologia software e hardware dei primi anni dell'informatica applicata ai personal computer e dispositivi di gioco.

E' composto da Hardware e software studiati per il backup di cartucce di gioco e applicativi del personal computer Commodore 64.

La componente Hardware utilizza la scheda Arduino Nano (ATMega328P) come controllore e degli Shift Register (74HC595) per estenderne gli I/O; mentre la parte software è formata dal firmware caricato sull'Arduino (aggiornabile tramite USB) ed un client Windows in C# per .Net Framework. Inoltre è stato creato un software per Windows per l'aggiornamento del firmware.

<p align="center" width="100%">
	<img src="https://github.com/DrVector-000/C64-Cartridge-Dumper/blob/main/Images/IMG_6074.jpg" alt="Dumper" width="400"/>
	<img src="https://github.com/DrVector-000/C64-Cartridge-Dumper/blob/main/Images/IMG_6076.jpg" alt="Cartridge" width="225"/>
</p>

<!---
![alt text](https://github.com/DrVector-000/C64-Cartridge-Dumper/blob/main/Images/IMG_6074.jpg?raw=true)
-->

## Funzionalità implementate e previste
- [x] Lettura e salvataggio su file delle cartucce standard 8k e 16k.

<!---
- [x] Backup ROM su file.
- [x] Backup RAM salvataggio del gioco su file.
	- [x] Memory Bank Controller MBC5.
	- [x] Memory Bank Controller MBC1.
	- [x] Memory Bank Controller MBC3. (Giochi serie Pokèmon)
	- [x] Memory Bank Controller MBC2. In fase di test.
	- [ ] Altri MBC
- [ ] Backup RAM GB Camera su file.
- [X] Restore RAM.
	- [x] Memory Bank Controller MBC5.
	- [x] Memory Bank Controller MBC1.
	- [x] Memory Bank Controller MBC3. (Giochi serie Pokèmon)
	- [x] Memory Bank Controller MBC2. In fase di test.
	- [ ] Altri MBC
- [ ] Restore ROM su Flash Carts.
- [X] Firmware aggiornabile.

![alt text](https://github.com/DrVector-000/GB-Cartridge-Dumper/blob/main/Images/GB%20Cartridge%20Dumper%20002.jpg?raw=true)

## Compatibilità
[Lista compatibilità](https://github.com/DrVector-000/GB-Cartridge-Dumper/blob/main/Docs/Compatibility%20List.txt)
-->

## Licenza
[MIT](https://github.com/DrVector-000/C64-Cartridge-Dumper/blob/main/LICENSE.txt)
