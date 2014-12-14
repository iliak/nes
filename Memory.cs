using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NES
{

	// [0x0000-0x00FF]	- RAM for Zero-Page & Indirect-Memory Addressing
	// [0x0100-0x01FF]	- RAM for Stack Space & Absolute Addressing
	// [0x0200-0x3FFF]	- RAM for programmer use
	// [0x4000-0x7FFF]	- Memory mapped I/O
	// [0x8000-0xFFF9]	- ROM for programmer useage
	// [0xFFFA]			- Vector address for NMI (low byte)
	// [0xFFFB]			- Vector address for NMI (high byte)
	// [0xFFFC]			- Vector address for RESET (low byte)
	// [0xFFFD]			- Vector address for RESET (high byte)
	// [0xFFFE]			- Vector address for IRQ & BRK (low byte)
	// [0xFFFF]			- Vector address for IRQ & BRK  (high byte)     

	// Address Range  	Size 			Notes (Page size is 256 bytes)
	// $0000–$00FF 		256 bytes 		Zero Page — Special Zero Page addressing modes give faster memory read/write access
	// $0100–$01FF 		256 bytes 		Stack memory
	// $0200–$07FF 		1536 bytes 		RAM
	// $0800–$0FFF 		2048 bytes 		Mirror of $0000–$07FF 	$0800–$08FF Zero Page
	//															$0900–$09FF	Stack
	//															$0A00–$0FFF	RAM
	// $1000–$17FF 		2048 bytes 		Mirror of $0000–$07FF 	$1000–$10FF Zero Page
	//															$1100–$11FF Stack
	//															$1200–$17FF RAM
	// $1800–$1FFF 		2048 bytes 		Mirror of $0000–$07FF 	$1800–$18FF Zero Page
	//															$1900–$19FF Stack
	//															$1A00–$1FFF RAM
	// $2000–$2007 		8 bytes 		Input/Output registers
	// $2008–$3FFF 		8184 bytes 		Mirror of $2000–$2007 (multiple times)
	// $4000–$401F 		32 bytes 		Input/Output registers
	// $4020–$5FFF 		8160 bytes 		Expansion ROM — Used with Nintendo's MMC5 to expand the capabilities of VRAM.
	// $6000–$7FFF 		8192 bytes 		SRAM — Save Ram used to save data between game plays.
	// $8000–$FFFF 		32768 bytes		PRG-ROM
	// $FFFA–$FFFB 		2 bytes 		Address of Non Maskable Interrupt (NMI) handler routine
	// $FFFC–$FFFD 		2 bytes 		Address of Power on reset handler routine
	// $FFFE–$FFFF 		2 bytes 		Address of Break (BRK instruction) handler routine

	/// <summary>
	/// 
	/// </summary>
	public class Memory
	{

		/// <summary>
		/// 
		/// </summary>
		public Memory()
		{
			RAM = new byte[0x10000];

		}


		/// <summary>
		/// Reads a 8 bits value
		/// </summary>
		/// <param name="addr">Offset</param>
		/// <returns>Value</returns>
		public byte ReadByte(int addr)
		{
			addr &= 0xFFFF;

			return RAM[addr];
		}



		/// <summary>
		/// Writes a 8 bits in memory
		/// </summary>
		/// <param name="addr">Offset</param>
		/// <param name="val">Value</param>
		/// <returns></returns>
		public void WriteByte(int addr, byte val)
		{
			addr &= 0xFFFF;

			#region [0x0000 - 0x00FF] - Zero page
			if (addr < 0x00FF)
			{

			}
			#endregion
			
			#region [0x0100 - 0x01FF] - Stack
			else if (addr < 0x01FF)
			{

			}
			#endregion
	
			#region [0x0200 - 0x07FF] - RAM
			else if (addr < 0x07FF)
			{
				// Raw tile index
				//76543210
				//||||||||
				//||||||++- Palette for top left
				//||||++--- Palette for top right
				//||++----- Palette for bottom left
				//++------- Palette for bottom right
				if (addr < 0x03bf)
				{

				}
				// Palette
				//fedcba98 76543210
				//vhpcccnn nnnnnnnn
				//|||||||| ||||||||
				//||||||++-++++++++- Tile index
				//|||+++------------ Color palette index
				//||+--------------- Priority (in front of or behind sprites?)
				//|+---------------- Horizontal flip
				//+----------------- Vertical flip
				else if (addr < 0x03ff)
				{

				}
			}
			#endregion

			#region [0x0800 - 0x0FFF] -
			else if (addr <= 0x0FFF)
			{

			}
			#endregion

			#region [0x1000 - 0x17FF] - Mirror of [0x0000 - 0x07FF]
			else if (addr < 0x17FF)
			{
				addr -= 0x1000;
			}
			#endregion

			#region [0x1800 - 0x1FFF] - Mirror of [0x0000 - 0x07FF]
			else if (addr < 0x1FFF)
			{
				addr -= 0x1800;
			}
			#endregion

			#region [0x2000 - 0x2007] - PPU I/O registers

			// PPU Control (R/W)
			//76543210
			//||||||||
			//||||||++- base nametable address
			//||||||    (00 = $2000; 01 = $2400; 02 = $2800; 03 = $2c00)
			//|||||+--- VRAM address increment
			//|||||     (0: increment by 1, going across; 1: increment by 32, going down)
			//||||+---- Sprite pattern table address for 8x8 sprites (0: $0000; 1: $1000)
			//|||+----- Background pattern table address (0: $0000; 1: $1000)
			//||+------ Sprite size (0: 8x8 sprites; 1: 8x16 sprites)
			//|+------- PPU layer select (should always be 0 in the NES; some Nintendo
			//|         arcade boards presumably had two PPUs)
			//+-------- Vertical blank NMI generation (0: off; 1: on)
			else if (addr == 0x2000)
			{

			}
			// PPU mask (R/W)
			//76543210
			//||||||||
			//|||||||+- Color disable (0: normal color; 1: AND all palette entries
			//|||||||   with 110000, effectively producing a monochrome display)
			//||||||+-- Show leftmost 8 pixels of background
			//|||||+--- Show sprites in leftmost 8 pixels
			//||||+---- Show background
			//|||+----- Show sprites
			//||+------ Intensify greens (and darken other colors)
			//|+------- Intensify blues (and darken other colors)
			//+-------- Intensify reds (and darken other colors)
			else if (addr == 0x2001)
			{

			}
			// PPU Status (R)
			//76543210
			//||||||||
			//|||+++++- Least significant bits of the last byte written to a PPU register
			//||+------ Sprite overflow. The PPU can handle only eight sprites on one
			//||        scanline and sets this bit if it starts drawing sprites.
			//|+------- Sprite 0 overlap.  Set when a nonzero pixel of sprite 0 is drawn
			//|         overlapping a nonzero background pixel.  Used for raster timing.
			//+-------- Vertical blank start (0: has not started; 1: has started)
			//Reading from $2002 will clear D7 of $2002 and also the $2005/$2006 latch.
			else if (addr == 0x2002)
			{

			}
			// OAM address (W)
			// Write the address of OAM memory you want to access here.
			else if (addr == 0x2003)
			{

			}
			// OAM data (W)
			// Write OAM data here.
			else if (addr == 0x2004)
			{

			}
			// Scroll register  (W)
			// After reading $2002, write the horizontal and vertical scroll offsets
			// here just before turning on the screen.
			else if (addr == 0x2005)
			{

			}
			// VRAM address register (W)
			// When the screen is turned off ($2001), write the address of PPU memory
			// you want to access here.
			else if (addr == 0x2006)
			{

			}
			// VRAM data register  (RW)
			// When the screen is turned off ($2001), read or write data from PPU
			// memory here.  Reads are delayed by one cycle; discard the first byte
			// read.
			else if (addr == 0x2007)
			{

			}
			#endregion

			#region [0x2008 - 0x3FFF] - Mirror of [0x2000 - 0x2007]
			else if (addr < 0x3FFF)
			{
				addr = (addr - 0x2008) % 8;
			}
			#endregion

			#region [0x4000 - 0x401F] - APU I/O registers
			else if (addr == 0x4000)		// pAPU Pulse 1 Control Register.
			{

			}
			else if (addr == 0x4001)		// pAPU Pulse 1 Ramp Control Register.
			{

			}
			else if (addr == 0x4002)		// pAPU Pulse 1 Fine Tune (FT) Register.
			{

			}
			else if (addr == 0x4003)		// pAPU Pulse 1 Coarse Tune (CT) Register.
			{

			}
			else if (addr == 0x4004)		// pAPU Pulse 2 Control Register.
			{

			}
			else if (addr == 0x4005)		// pAPU Pulse 2 Ramp Control Register.
			{

			}
			else if (addr == 0x4006)		// pAPU Pulse 2 Fine Tune Register.
			{

			}
			else if (addr == 0x4007)		// pAPU Pulse 2 Coarse Tune Register.
			{

			}
			else if (addr == 0x4008)		// pAPU Triangle Control Register 1.
			{

			}
			else if (addr == 0x4009)		// pAPU Triangle Control Register 2.
			{

			}
			else if (addr == 0x400A)		// pAPU Triangle Frequency Register 1.
			{

			}
			else if (addr == 0x400B)		// pAPU Triangle Frequency Register 2.
			{

			}
			else if (addr == 0x400C)		// pAPU Noise Control Register 1.
			{

			}
			else if (addr == 0x400D)		// 
			{

			}
			else if (addr == 0x400E)		// pAPU Noise Frequency Register 1.
			{

			}
			else if (addr == 0x400F)		// pAPU Noise Frequency Register 2.
			{

			}
			else if (addr == 0x4010)		// pAPU Delta Modulation Control Register.
			{

			}
			else if (addr == 0x4011)		// pAPU Delta Modulation D/A Register.
			{

			}
			else if (addr == 0x4012)		// pAPU Delta Modulation Address Register.
			{

			}
			else if (addr == 0x4013)		// pAPU Delta Modulation Data Length Register.
			{

			}
			else if (addr == 0x4014)		// Sprite DMA Register
			{

			}
			else if (addr == 0x4015)		// pAPU Sound / Vertical Clock Signal Register.
			{

			}
			else if (addr == 0x4016)		// Joypad 1:
			{

			}
			else if (addr == 0x4017)		// Joypad 2:
			{

			}
			#endregion

			#region [0x4020 - 0x5FFF] - Expansion ROM
			else if (addr < 0x5FFF)
			{

			}
			#endregion

			#region [0x6000 - 0x7FFF] - SRAM - Save RAM used to save data between gameplays
			else if (addr < 0x7FFF)
			{

			}
			#endregion

			#region [0x8000 - 0xFFF9] - PRG ROM
			else if (addr < 0xFFF9)
			{

			}
			#endregion

			#region [0xFFFA - 0xFFFB] - Address of NMI instruction handler routine
			else if (addr < 0xFFFB)
			{

			}
			#endregion

			#region [0xFFFC - 0xFFFD] - Address of RST instruction handler routine
			else if (addr < 0xFFFD)
			{

			}
			#endregion

			#region [0xFFFE - 0xFFFF] - Address of BRK instruction handler routine
			else if (addr < 0xFFFF)
			{

			}
			#endregion

			RAM[addr & 0xFFFF] = val;
		}



		/// <summary>
		/// Reads a 16 bits value
		/// </summary>
		/// <param name="addr">Offset</param>
		/// <returns>Value</returns>
		public ushort ReadShort(int addr)
		{
			return (ushort)(ReadByte(addr) | ReadByte((ushort)(addr + 1)) << 8);
		}



		/// <summary>
		/// Writes a 16 bits value
		/// </summary>
		/// <param name="addr">Offset</param>
		/// <param name="val">Value</param>
		public void WriteShort(int addr, ushort val)
		{
			byte l = (byte)(val & 0xFF);
			byte h = (byte)((val & 0xFF00) >> 8);

			WriteByte(addr, h);
			WriteByte((ushort)(addr + 1), l);
		}


		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public byte[] RAM;

		#endregion


	}
}
