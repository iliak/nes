using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




//												NTSC		PAL
//Frames per second								60			50
//Time per frame (milliseconds)					16.67		20
//Scanlines per frame (of which is V-Blank)		262 (20)	312 (70)
//CPU cycles per scanline						113.33		106.56
//Resolution									256 x 224	256 x 240
//CPU speed										1.79 MHz	1.66 MHz
namespace NES
{
	/// <summary>
	/// MOS6502 cpu emulator
	/// 
	/// <see cref="http://skilldrick.github.io/easy6502/"/>
	/// <see cref="http://www.obelisk.demon.co.uk/6502/index.html"/>
	/// <see cref="http://fms.komkon.org/EMUL8/NES.html"/>
	/// <see cref="http://problemkaputt.de/everynes.htm"/>
	/// </summary>
	public class MOS6502
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MOS6502(Memory mem)
		{
			Memory = mem;

			ResetVector = 0xC000;

			Reset();
		}

		/// <summary>
		/// 
		/// </summary>
		public void Reset()
		{
			OpCode = 0;
			PC = 0xC000;
			SP = 0xFF;
			//ResetVector = 0xC000;
			A = 0;
			X = 0;
			Y = 0;
			M = 0;

			N = false;
			V = false;
			B = false;
			D = false;
			I = true;
			Z = false;
			C = false;

			Cycles = 0;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string Disassemble()
		{
			StringBuilder sb = new StringBuilder();

			ushort pc = 0xc000;
			byte b = 0;
			ushort s = 0;

			while (pc < 0xFFFA)
			{
				byte opcode = Memory.ReadByte(pc);
				string pos = "$" + pc.ToString("X4") + "\t";

				pc++;

				switch (opcode)
				{
					#region ADC

					case 0x61:
					{
						b = Memory.ReadByte(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, b, "ADC ($" + b.ToString("X2") + ", X)"));
						pc++;
					}
					break;
					case 0x65:
					{
						b = Memory.ReadByte(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, b, "ADC $" + b.ToString("X2")));
						//sb.AppendLine(pos + "65 " + b.ToString("X2") + "	ADC $" + b.ToString("X2"));
						pc++;
					}
					break;
					case 0x69:
					{
						b = Memory.ReadByte(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, b, "ADC #$" + b.ToString("X2")));
						//sb.AppendLine(pos + "69 " + b.ToString("X2") + "	ADC #$" + b.ToString("X2"));
						pc++;
					}
					break;
					case 0x6D:
					{
						s = Memory.ReadShort(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, s, "ADC $" + s.ToString("X4")));
						//sb.AppendLine(DumpOpcode(pc, opcode, s, "ADC $" + s.ToString("X4")));
						pc += 2;
					}
					break;
					case 0x71:
					{
						b = Memory.ReadByte(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, b, "ADC ($" + b.ToString("X2") + "), Y"));
						//sb.AppendLine(pos + "71 " + b.ToString("X2") + "	ADC ($" + b.ToString("X2") + "), Y");
						pc++;
					}
					break;
					case 0x75:
					{
						b = Memory.ReadByte(pc);
						//sb.AppendLine(pos + "75 " + s.ToString("X2") + "	ADC $" + b.ToString("X2") + ", X");
						sb.AppendLine(DumpOpcode(pc, opcode, b, "ADC $" + b.ToString("X2") + ", X)"));
						pc++;
					}
					break;
					case 0x79:
					{
						s = Memory.ReadShort(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, s, "ADC $" + s.ToString("X4") + ", Y"));
						pc += 2;
						//sb.AppendLine(pos + "79 " + s.ToString("X4") + "	ADC $" + s.ToString("X4") + ", Y");
					}
					break;
					case 0x7D:
					{
						s = Memory.ReadShort(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, s, "ADC $" + s.ToString("X2") + ", X"));
						pc += 2;
						//sb.AppendLine(pos + "7d " + s.ToString("X4") + "	ADC $" + s.ToString("X4") + ", X");
					}
					break;

					#endregion

					#region AND

					case 0x21:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "AND ($" + b.ToString("X2") + ", X)");
					}
					break;
					case 0x25:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "AND $" + b.ToString("X2"));
					}
					break;
					case 0x29:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "AND #$" + b.ToString("X2"));
					}
					break;
					case 0x2d:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "AND $" + s.ToString("X4"));
					}
					break;
					case 0x31:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "AND ($" + b.ToString("X2") + "), Y");
					}
					break;
					case 0x35:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "AND $" + b.ToString("X2") + ", X");
					}
					break;
					case 0x39:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "AND $" + s.ToString("X4") + ", Y");
					}
					break;
					case 0x3d:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "AND $" + s.ToString("X4") + ", X");
					}
					break;

					#endregion

					#region ASL
					case 0x06:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "ASL $" + b.ToString("X2"));
					}
					break;
					case 0x0a:
					{
						sb.AppendLine(pos + "ASL A");
					}
					break;
					case 0x0e:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "ASL $" + s.ToString("X4"));
					}
					break;
					case 0x16:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "ASL $" + b.ToString("X2") + ", X");
					}
					break;
					case 0x1e:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "ASL $" + s.ToString("X4") + ", X");
					}
					break;

					#endregion

					#region BCC
					case 0x90:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "BCC $" + b.ToString("X2") + "\t; => $" + (pc + (sbyte)b).ToString("X4"));
					}
					break;
					#endregion

					#region BCS
					case 0xb0:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "BCS $" + b.ToString("X2") + "\t; => $" + (pc + (sbyte)b).ToString("X4"));
					}
					break;
					#endregion

					#region BEQ
					case 0xF0:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "BEQ $" + b.ToString("X2") + "\t; => $" + (pc + (sbyte)b).ToString("X4"));
					}
					break;
					#endregion

					#region BIT
					case 0x24:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "BIT $" + b.ToString("X2"));
					}
					break;
					case 0x2c:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "BIT $" + s.ToString("X4"));
					}
					break;
					#endregion

					#region BMI
					case 0x30:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "BMI $" + b.ToString("X2") + "\t; => $" + (pc + (sbyte)b).ToString("X4"));
					}
					break;
					#endregion

					#region BNE
					case 0xd0:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "BNE $" + b.ToString("X2") + "\t; => $" + (pc + (sbyte)b).ToString("X4"));
					}
					break;
					#endregion

					#region BPL
					case 0x10:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "BPL $" + b.ToString("X2") + "\t; => $" + (pc + (sbyte)b).ToString("X4"));
					}
					break;
					#endregion

					#region BRK
					case 0x00:
					{
						sb.AppendLine(pos + "BRK");
					}
					break;
					#endregion

					#region BVC
					case 0x50:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "BVC $" + b.ToString("X2") + "\t; => $" + (pc + (sbyte)b).ToString("X4"));
					}
					break;
					#endregion

					#region BVS
					case 0x70:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "BVS $" + b.ToString("X2") + "\t; => $" + (pc + (sbyte)b).ToString("X4"));
					}
					break;
					#endregion

					#region CLC
					case 0x18:
					{
						sb.AppendLine(pos + "CLC");
					}
					break;
					#endregion

					#region CLD
					case 0xd8:
					{
						//sb.AppendLine(pos + "CLD");
						sb.AppendLine(DumpOpcode(pc, opcode, "CLD"));
					}
					break;
					#endregion

					#region CLI
					case 0x58:
					{
						sb.AppendLine(pos + "CLI");
					}
					break;
					#endregion

					#region CLV
					case 0xb8:
					{
						sb.AppendLine(pos + "CLV");
					}
					break;
					#endregion

					#region CMP
					case 0xc1:
					{
						b = Memory.ReadByte(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, b, "CMP ($" + b.ToString("X2") + "), Y"));
						//sb.AppendLine(pos + "CMP ($" + b.ToString("X2") + "), Y");
						pc++;
					}
					break;
					case 0xc5:
					{
						b = Memory.ReadByte(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, b, "CMP $" + b.ToString("X2")));
						//sb.AppendLine(pos + "CMP $" + b.ToString("X2"));
						pc++;
					}
					break;
					case 0xc9:
					{
						b = Memory.ReadByte(pc);
						//sb.AppendLine(pos + "CMP #$" + b.ToString("X2"));
						sb.AppendLine(DumpOpcode(pc, opcode, b, "CMP #$" + b.ToString("X2")));
						pc++;
					}
					break;
					case 0xcd:
					{
						s = Memory.ReadShort(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, s, "CMP $" + s.ToString("X4")));
						pc += 2;
						//sb.AppendLine(pos + "CMP $" + s.ToString("X4"));
					}
					break;
					case 0xd1:
					{
						b = Memory.ReadByte(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, b, "CMP ($" + b.ToString("X2") + ", X)"));
						pc++;
						//sb.AppendLine(pos + "CMP ($" + b.ToString("X2") + ", X)");
					}
					break;
					case 0xd5:
					{
						b = Memory.ReadByte(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, b, "CMP $" + b.ToString("X2") + ", X"));
						pc++;
						//sb.AppendLine(pos + "CMP $" + b.ToString("X2") + ", X");
					}
					break;
					case 0xd9:
					{
						s = Memory.ReadShort(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, s, "CMP $" + s.ToString("X4") + ", Y"));
						pc += 2;
						//sb.AppendLine(pos + "CMP $" + s.ToString("X4") + ", Y");
					}
					break;
					case 0xdd:
					{
						s = Memory.ReadShort(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, s, "CMP $" + s.ToString("X4") + ", X"));
						pc += 2;
						//sb.AppendLine(pos + "CMP $" + s.ToString("X4") + ", X");
					}
					break;
					#endregion

					#region CPX
					case 0xe0:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "CPX #$" + b.ToString("X2"));
					}
					break;
					case 0xe4:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "CPX $" + b.ToString("X2"));
					}
					break;
					case 0xec:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "CPX $" + s.ToString("X4"));
					}
					break;
					#endregion

					#region CPY
					case 0xc0:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "CPY #$" + b.ToString("X2"));
					}
					break;
					case 0xc4:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "CPY $" + b.ToString("X2"));
					}
					break;
					case 0xcc:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "CPY $" + s.ToString("X4"));
					}
					break;
					#endregion

					#region DEC
					case 0xc6:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "DEC $" + b.ToString("X2"));
					}
					break;
					case 0xd6:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "DEC $" + b.ToString("X2") + ", X");
					}
					break;
					case 0xce:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "DEC $" + s.ToString("X4"));
					}
					break;
					case 0xde:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "DEC $" + s.ToString("X4") + ", X");
					}
					break;
					#endregion

					#region DEX
					case 0xca:
					{
						sb.AppendLine(pos + "DEX");
					}
					break;
					#endregion

					#region DEY
					case 0x88:
					{
						sb.AppendLine(pos + "DEY");
					}
					break;
					#endregion

					#region EOR
					case 0x41:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "EOR ($" + b.ToString("X2") + ", X)");
					}
					break;
					case 0x45:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "EOR $" + b.ToString("X2"));
					}
					break;
					case 0x49:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "EOR #$" + b.ToString("X2"));
					}
					break;
					case 0x4d:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "EOR $" + s.ToString("X4"));
					}
					break;
					case 0x51:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "EOR ($" + b.ToString("X2") + "), Y");
					}
					break;
					case 0x55:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "EOR $" + b.ToString("X2") + ", X");
					}
					break;
					case 0x59:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "EOR $" + s.ToString("X4") + ", Y");
					}
					break;
					case 0x5d:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "EOR $" + s.ToString("X4") + ", X");
					}
					break;
					#endregion

					#region INC
					case 0xe6:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "INC $" + b.ToString("X2"));
					}
					break;
					case 0xee:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "INC $" + s.ToString("X4"));
					}
					break;
					case 0xf6:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "INC $" + b.ToString("X2") + ", X");
					}
					break;
					case 0xfe:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "INC $" + s.ToString("X4") + ", X");
					}
					break;
					#endregion

					#region INX
					case 0xe8:
					{
						sb.AppendLine(pos + "INX");
					}
					break;
					#endregion

					#region INY
					case 0xc8:
					{
						sb.AppendLine(pos + "INY");
					}
					break;
					#endregion

					#region JMP
					case 0x4c:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "JMP $" + s.ToString("X4"));
					}
					break;
					case 0x6c:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "JMP ($" + s.ToString("X4") + ")");
					}
					break;
					#endregion

					#region JSR
					case 0x20:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "JSR $" + s.ToString("X4"));
					}
					break;
					#endregion

					#region LDA
					case 0xa1:
					{
						b = Memory.ReadByte(pc);
						//sb.AppendLine(pos + "LDA ($" + b.ToString("X2") + ", X)");
						sb.AppendLine(DumpOpcode(pc, opcode, b, "LDA ($" + b.ToString("X2") + ", X)"));
						pc++;
					}
					break;
					case 0xa5:
					{
						b = Memory.ReadByte(pc);
						//sb.AppendLine(pos + "LDA $" + b.ToString("X2"));
						sb.AppendLine(DumpOpcode(pc, opcode, b, "LDA $" + b.ToString("X2")));
						pc++;
					}
					break;
					case 0xa9:
					{
						b = Memory.ReadByte(pc);
						//sb.AppendLine(pos + "LDA #$" + b.ToString("X2"));
						sb.AppendLine(DumpOpcode(pc, opcode, b, "LDA #$" + b.ToString("X2")));
						pc++;
					}
					break;
					case 0xad:
					{
						s = Memory.ReadShort(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, b, "LDA $" + s.ToString("X4")));
						pc += 2;
						//sb.AppendLine(pos + "LDA $" + s.ToString("X4"));
					}
					break;
					case 0xb1:
					{
						b = Memory.ReadByte(pc);
						//sb.AppendLine(pos + "LDA ($" + b.ToString("X2") + "), Y");
						sb.AppendLine(DumpOpcode(pc, opcode, b, "LDA ($" + b.ToString("X2") + "), Y"));
						pc++;
					}
					break;
					case 0xb5:
					{
						b = Memory.ReadByte(pc);
						//sb.AppendLine(pos + "LDA $" + b.ToString("X2") + ", X");
						sb.AppendLine(DumpOpcode(pc, opcode, b, "LDA $" + b.ToString("X2") + ", X"));
						pc++;
					}
					break;
					case 0xb9:
					{
						s = Memory.ReadShort(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, s, "LDA $" + s.ToString("X4") + ", Y"));
						pc += 2;
						//sb.AppendLine(pos + "LDA $" + s.ToString("X4") + ", Y");
					}
					break;
					case 0xbd:
					{
						s = Memory.ReadShort(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, s, "LDA $" + b.ToString("X4") + ", X"));
						pc += 2;
						//sb.AppendLine(pos + "LDA $" + s.ToString("X4") + ", X");
					}
					break;
					#endregion

					#region LDX
					case 0xa2:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "LDX #$" + b.ToString("X2"));
					}
					break;
					case 0xa6:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "LDX $" + s.ToString("X4"));
					}
					break;
					case 0xae:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "LDX $" + s.ToString("X4"));
					}
					break;
					case 0xb6:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "LDX $" + b.ToString("X2") + ", Y");
					}
					break;
					case 0xbe:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "LDX $" + s.ToString("X4") + ", Y");
					}
					break;
					#endregion

					#region LDY
					case 0xa0:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "LDY #$" + b.ToString("X2"));
					}
					break;
					case 0xa4:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "LDY $" + b.ToString("X2"));
					}
					break;
					case 0xac:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "LDY $" + s.ToString("X4"));
					}
					break;
					case 0xb4:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "LDY $" + b.ToString("X2") + ", X");
					}
					break;
					case 0xbc:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "LDY $" + s.ToString("X4") + ", X");
					}
					break;
					#endregion

					#region LSR
					case 0x46:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "LSR $" + b.ToString("X2"));
					}
					break;
					case 0x4a:
					{
						sb.AppendLine(pos + "LSR A");
					}
					break;
					case 0x4e:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "LSR $" + s.ToString("X4"));
					}
					break;
					case 0x56:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "LSR $" + b.ToString("X2") + ", X");
					}
					break;
					case 0x5e:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "LSR $" + s.ToString("X4") + ", X");
					}
					break;
					#endregion

					#region NOP
					case 0xEA:
					{
						sb.AppendLine(pos + "NOP");
					}
					break;
					#endregion

					#region ORA
					case 0x01:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "ORA ($" + b.ToString("X2") + ", X)");
					}
					break;
					case 0x05:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "ORA $" + b.ToString("X2"));
					}
					break;
					case 0x09:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "ORA #$" + b.ToString("X2"));
					}
					break;
					case 0x0d:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "ORA $" + s.ToString("X4"));
					}
					break;
					case 0x11:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "ORA ($" + b.ToString("X2") + "), Y");
					}
					break;
					case 0x15:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "ORA $" + b.ToString("X2") + ", X");
					}
					break;
					case 0x19:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "ORA $" + s.ToString("X4") + ", Y");
					}
					break;
					case 0x1d:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "ORA $" + s.ToString("X4") + ", X");
					}
					break;
					#endregion

					#region PHA
					case 0x48:
					{
						sb.AppendLine(pos + "PHA");
					}
					break;
					#endregion

					#region PHP
					case 0x08:
					{
						sb.AppendLine(pos + "PHP");
					}
					break;
					#endregion

					#region PLA
					case 0x68:
					{
						sb.AppendLine(pos + "PLA");
					}
					break;
					#endregion

					#region PLP
					case 0x28:
					{
						sb.AppendLine(pos + "PLP");
					}
					break;
					#endregion

					#region ROL
					case 0x2a:
					{
						sb.AppendLine(pos + "ROL A");
					}
					break;
					case 0x26:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "ROL $" + b.ToString("X2"));
					}
					break;
					case 0x36:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "ROL $" + b.ToString("X2") + ", X");
					}
					break;
					case 0x2e:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "ROL $" + s.ToString("X4"));
					}
					break;
					case 0x3e:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "ROL $" + s.ToString("X4") + ", X");
					}
					break;
					#endregion

					#region ROR
					case 0x6a:
					{
						sb.AppendLine(pos + "ROR A");
					}
					break;
					case 0x66:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "ROR $" + b.ToString("X2"));
					}
					break;
					case 0x76:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "ROR $" + b.ToString("X2") + ", X");
					}
					break;
					case 0x6e:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "ROR $" + s.ToString("X4"));
					}
					break;
					case 0x7e:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "ROR $" + s.ToString("X4") + ", X");
					}
					break;
					#endregion

					#region RTI
					case 0x40:
					{
						sb.AppendLine(pos + "RTI");
					}
					break;
					#endregion

					#region RTS
					case 0x60:
					{
						sb.AppendLine(pos + "RTS-----------------------");
					}
					break;
					#endregion

					#region SBC
					case 0xe9:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "SBC #$" + b.ToString("X2"));
					}
					break;
					case 0xe5:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "SBC $" + b.ToString("X2"));
					}
					break;
					case 0xf5:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "SBC $" + b.ToString("X2") + ", X");
					}
					break;
					case 0xed:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "SBC $" + s.ToString("X4"));
					}
					break;
					case 0xfd:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "SBC $" + s.ToString("X4") + ", X");
					}
					break;
					case 0xf9:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "SBC $" + s.ToString("X4") + ", Y");
					}
					break;
					case 0xe1:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "SBC ($" + b.ToString("X2") + ", X)");
					}
					break;
					case 0xf1:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "SBC ($" + b.ToString("X2") + "), Y");
					}
					break;
					#endregion

					#region SEC
					case 0x38:
					{
						sb.AppendLine(pos + "SEC");
					}
					break;
					#endregion

					#region SED
					case 0xF8:
					{
						sb.AppendLine(pos + "SED");
					}
					break;
					#endregion

					#region SEI
					case 0x78:
					{
						//sb.AppendLine(pos + "SEI");
						sb.AppendLine(DumpOpcode(pc, opcode, "SEI"));
					}
					break;
					#endregion

					#region STA
					case 0x85:
					{
						b = Memory.ReadByte(pc);
						//sb.AppendLine(pos + "STA $" + b.ToString("X2"));
						sb.AppendLine(DumpOpcode(pc, opcode, b, "STA $" + b.ToString("X2")));
						pc++;
					}
					break;
					case 0x95:
					{
						b = Memory.ReadByte(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, b, "STA $" + b.ToString("X2") + ", X"));
						//sb.AppendLine(pos + "STA $" + b.ToString("X2") + ", X");
						pc++;
					}
					break;
					case 0x8d:
					{
						s = Memory.ReadShort(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, s, "STA $" + s.ToString("X4")));
						pc += 2;
						//sb.AppendLine(pos + "STA $" + s.ToString("X4"));
					}
					break;
					case 0x9d:
					{
						s = Memory.ReadShort(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, s, "STA $" + s.ToString("X4") + ", X"));
						pc += 2;
						//sb.AppendLine(pos + "STA $" + s.ToString("X4") + ", X");
					}
					break;
					case 0x99:
					{
						s = Memory.ReadShort(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, s, "STA $" + s.ToString("X4") + ", Y"));
						pc += 2;
						//sb.AppendLine(pos + "STA $" + s.ToString("X4") + ", Y");
					}
					break;
					case 0x81:
					{
						b = Memory.ReadByte(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, b, "STA ($" + b.ToString("X2") + ", X)"));
						pc++;
						//sb.AppendLine(pos + "STA ($" + b.ToString("X2") + ", X)");
					}
					break;
					case 0x91:
					{
						b = Memory.ReadByte(pc);
						sb.AppendLine(DumpOpcode(pc, opcode, b, "STA ($" + b.ToString("X2") + "), Y"));
						pc++;
						//sb.AppendLine(pos + "STA ($" + b.ToString("X2") + "), Y");
					}
					break;
					#endregion

					#region STX
					case 0x86:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "STX $" + b.ToString("X2"));
					}
					break;
					case 0x8e:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "STX $" + s.ToString("X4"));
					}
					break;
					case 0x96:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "STX $" + b.ToString("X2") + ", X");
					}
					break;
					#endregion

					#region STY
					case 0x84:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "STY $" + b.ToString("X2"));
					}
					break;
					case 0x8c:
					{
						s = Memory.ReadShort(pc);
						pc += 2;
						sb.AppendLine(pos + "STY $" + s.ToString("X4"));
					}
					break;
					case 0x94:
					{
						b = Memory.ReadByte(pc++);
						sb.AppendLine(pos + "STY $" + b.ToString("X2") + ", X");
					}
					break;
					#endregion

					#region TAX
					case 0xaa:
					{
						sb.AppendLine(pos + "TAX");
					}
					break;
					#endregion

					#region TAY
					case 0xa8:
					{
						sb.AppendLine(pos + "TAY");
					}
					break;
					#endregion

					#region TSX
					case 0xba:
					{
						sb.AppendLine(pos + "TSX");
					}
					break;
					#endregion

					#region TXA
					case 0x8a:
					{
						sb.AppendLine(pos + "TXA");
					}
					break;
					#endregion

					#region TXS
					case 0x9a:
					{
						sb.AppendLine(pos + "TXS");
					}
					break;
					#endregion

					#region TYA
					case 0x98:
					{
						sb.AppendLine(pos + "TYA");
					}
					break;
					#endregion

					default:
					{
						//sb.AppendLine(pos + "??? $" + opcode.ToString("X2"));
						sb.AppendLine(DumpOpcode(pc, opcode, "???"));
					}
					break;

				}
			}


			return sb.ToString();
		}


		private string DumpOpcode(int pos, byte opcode, string decode)
		{
			pos--;
			return "$" + pos.ToString("X4") + " " + opcode.ToString("X2") + "       " + decode;
		}

		private string DumpOpcode(int pos, byte opcode, byte arg, string decode)
		{
			pos--;
			return "$" + pos.ToString("X4") + " " + opcode.ToString("X2") + " " + arg.ToString("X2") + "    " + decode;
		}

		private string DumpOpcode(int pos, byte opcode, ushort arg, string decode)
		{
			pos--;
			byte arg1 = (byte)(arg & 0xff);
			byte arg2 = (byte)((arg & 0xff00) >> 8);
			return "$" + pos.ToString("X4") + " " + opcode.ToString("X2") + " " + arg1.ToString("X2") + " " + arg2.ToString("X2") + "   " + decode;
		}

		/// <summary>
		/// Assemble source code
		/// </summary>
		/// <param name="source">program listing</param>
		/// <returns></returns>
		public byte[] Assemble(string source)
		{

			return null;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="stepout">if true then step ou the instruction</param>
		public void Step(bool stepout = false)
		{

			OpCode = Memory.ReadByte(PC++);

			switch (OpCode)
			{
				#region ADC - ADd Memory to A with Carry
				case 0x61:
				{
					IndirectX_R();
					ADC();
				}
				break;
				case 0x65:
				{
					ZeroPage_R();
					ADC();
				}
				break;
				case 0x69:
				{
					Immediate();
					ADC();

					Cycles += 2;
				}
				break;
				case 0x6d:
				{
					Absolute_R();
					ADC();
				}
				break;
				case 0x71:
				{
					ADC();
				}
				break;
				case 0x75:
				{
					ZeroPageX_R();
					ADC();
				}
				break;
				case 0x79:
				{
					AbsoluteY_R();
					ADC();
				}
				break;
				case 0x7d:
				{
					AbsoluteX_R();
					ADC();
				}
				break;
				#endregion

				#region AND - Bitwise-AND A with Memory
				case 0x21:
				{
					s = Memory.ReadShort(PC);
					PC += 2;

					b = Memory.ReadByte(s + Y);

					A = (byte)(A & b);

					Cycles += 6;
				}
				break;
				case 0x29:
				{
					b = Memory.ReadByte(PC++);

					A &= b;
					Cycles += 2;
				}
				break;
				case 0x25:
				{
					b = Memory.ReadByte(PC++);
					A &= Memory.ReadByte(b);
					Cycles += 2;
				}
				break;
				case 0x2D:
				{
					s = Memory.ReadShort(PC);
					PC += 2;

					b = Memory.ReadByte(s);

					A = (byte)(A & b);

					Cycles += 4;
				}
				break;
				case 0x31:
				{

				}
				break;
				case 0x35:
				{
					b = Memory.ReadByte(PC++);

					A &= Memory.ReadByte(b + X);

					Cycles += 3;
				}
				break;
				case 0x39:
				{
					s = Memory.ReadShort(PC);
					PC += 2;

					b = Memory.ReadByte(s + Y);

					A = (byte)(A & b);

					Cycles += 4;
				}
				break;
				case 0x3D:
				{
					s = Memory.ReadShort(PC);
					PC += 2;

					b = Memory.ReadByte(s + X);

					A = (byte)(A & b);

					Cycles += 4;
				}
				break;
				#endregion

				#region ASL - Arithmetic Shift Left
				case 0x0a:
				{

				}
				break;
				case 0x06:
				{

				}
				break;
				case 0x16:
				{

				}
				break;
				case 0x0e:
				{

				}
				break;
				case 0x1e:
				{

				}
				break;
				#endregion

				#region BCC - Branch if P.C is CLEAR
				case 0x90:
				{
					b = Memory.ReadByte(PC);
					PC++;
					if (!C)
					{
						PC += b;
					}
					Cycles = 2;
				}
				break;
				#endregion

				#region BCS - Branch if P.C is SET
				case 0xb0:
				{
					b = Memory.ReadByte(PC);
					PC++;
					if (C)
					{
						PC += b;
					}
					Cycles = 2;
				}
				break;
				#endregion

				#region BEQ - Branch if P.Z is SET
				case 0xf0:
				{
					b = Memory.ReadByte(PC);
					PC++;
					if (Z)
					{
						PC += b;
					}
					Cycles += 2;
				}
				break;
				#endregion

				#region BIT - Test bits in A with M
				case 0x24:
				{
					b = Memory.ReadByte(PC++);

					b = Memory.ReadByte(b);

					V = CheckBit(b, 6);
					N = b < 0;
					Z = b == 0;

					Cycles += 3;
				}
				break;
				case 0x2C:
				{
					s = Memory.ReadShort(PC);
					PC += 2;

					b = Memory.ReadByte(s);

					V = CheckBit(b, 6);
					N = b < 0;
					Z = b == 0;

					Cycles += 4;
				}
				break;
				#endregion

				#region BMI - Branch if P.N is SET
				case 0x30:
				{

				}
				break;
				#endregion

				#region BNE - Branch Not Equals
				case 0xd0:
				{
					sb = (sbyte)Memory.ReadByte(PC);
					b = Memory.ReadByte(PC);

					PC++;

					if (!Z)
					{
						PC = (ushort)(PC + sb);
						Cycles++;
					}

					Cycles += 2;
				}
				break;
				#endregion

				#region BPL - Branch if P.N is CLEAR
				case 0x10:
				{
					sb = (sbyte)Memory.ReadByte(PC++);

					if (!N)
					{
						PC = (ushort)(PC + sb);

						Cycles++;
					}

					Cycles += 2;
				}
				break;
				#endregion

				#region BRK - Simulate Interrupt ReQuest (IRQ)
				case 0x00:
				{
					BRK();
					Cycles += 7;
				}
				break;
				#endregion

				#region BVC - Branch if P.V is CLEAR
				case 0x50:
				{
					b = Memory.ReadByte(PC++);
					if (!V)
					{
						PC += b;
					}
					Cycles += 2;
				}
				break;
				#endregion

				#region BVS - Branch if P.V is SET
				case 0x70:
				{
					b = Memory.ReadByte(PC);
					PC++;
					if (V)
					{
						PC += b;
					}
					Cycles += 2;
				}
				break;
				#endregion

				#region CLC - Clear Carry Flag (P.C)
				case 0x18:
				{
					C = false;
					Cycles = 2;
				}
				break;
				#endregion

				#region CLD - Clear Decimal Flag
				case 0xd8:
				{
					D = false;
					Cycles += 2;
				}
				break;
				#endregion

				#region CLI - Clear Interrupt (disable) Flag (P.I)
				case 0x58:
				{
					I = false;
					Cycles = 2;
				}
				break;
				#endregion

				#region CLV - Clear oVerflow Flag (P.V)
				case 0xB8:
				{
					V = false;
					Cycles = 2;
				}
				break;
				#endregion

				#region CMP - Compare A with Memory
				case 0xc9:
				{
					b = Memory.ReadByte(PC++);

					C = A >= b;
					Z = A == b;
					N = CheckBit(b, 7);

					Cycles += 2;
				}
				break;
				case 0xc5:
				{

				}
				break;
				case 0xd5:
				{

				}
				break;
				case 0xcd:
				{

				}
				break;
				case 0xdd:
				{

				}
				break;
				case 0xd9:
				{

				}
				break;
				case 0xc1:
				{

				}
				break;
				case 0xd1:
				{

				}
				break;

				#endregion

				#region CPX -Compare X with Memory
				case 0xe0:
				{

				}
				break;
				case 0xe4:
				{

				}
				break;
				case 0xec:
				{

				}
				break;
				#endregion

				#region CPY - Compare Y with Memory
				case 0xc0:
				{

				}
				break;
				case 0xc4:
				{

				}
				break;
				case 0xcc:
				{

				}
				break;
				#endregion

				#region DEC - Decrement Memory by one
				case 0xc6:
				{

				}
				break;
				case 0xd6:
				{

				}
				break;
				case 0xce:
				{

				}
				break;
				case 0xde:
				{

				}
				break;
				#endregion

				#region DEX - DEcrement X
				case 0xca:
				{
					X--;
					N = X < 0;
					Z = X == 0;

					Cycles += 2;
				}
				break;
				#endregion

				#region DEY - DEcrement Y
				case 0x88:
				{
					Y--;
					N = Y < 0;
					Z = Y == 0;

					Cycles += 2;
				}
				break;
				#endregion

				#region EOR - Bitwise-EXclusive-OR A with Memory
				case 0x49:
				{

				}
				break;
				case 0x45:
				{

				}
				break;
				case 0x55:
				{

				}
				break;
				case 0x4d:
				{

				}
				break;
				case 0x5d:
				{

				}
				break;
				case 0x59:
				{

				}
				break;
				case 0x41:
				{

				}
				break;
				case 0x51:
				{

				}
				break;
				#endregion

				#region INC - INCrement memory
				case 0xee:
				{
					s = Memory.ReadShort(PC);
					PC += 2;

					b = Memory.ReadByte(s);
					b++;
					Memory.WriteByte(s, b);


					Z = b == 0;
					N = b < 0;

					Cycles += 6;
				}
				break;
				case 0xe6:
				{

				}
				break;
				case 0xf6:
				{

				}
				break;
				case 0xfe:
				{

				}
				break;
				#endregion

				#region INX - INcrement X
				case 0xe8:
				{
					X++;
					Cycles += 2;
				}
				break;
				#endregion

				#region INY - INcrement Y
				case 0xc8:
				{
					Y++;
					Z = Y == 0;
					N = Y < 0;

					Cycles += 2;
				}
				break;
				#endregion

				#region JMP JuMP
				case 0x4C:
				{
					PC = Memory.ReadShort(PC);
					Cycles += 3;
				}
				break;
				case 0x6c:
				{

				}
				break;
				#endregion

				#region JSR - Jump SubRoutine
				case 0x20:
				{
					PushShort(PC);
					PC = Memory.ReadShort(PC);

					Cycles += 6;
				}
				break;
				#endregion

				#region LDA - Load A with memory
				case 0xa1:
				{
					IndirectX_R();
					LDA();

					Cycles += 6;
				}
				break;
				case 0xA5:
				{
					ZeroPage_R();
					LDA();

					Cycles += 3;
				}
				break;

				case 0xa9:
				{
					Immediate();
					LDA();

					Cycles += 2;
				}
				break;

				case 0xad:
				{
					Absolute_R();
					LDA();

					Cycles += 4;
				}
				break;

				case 0xb1:
				{
					IndirectY_R();
					LDA();

					Cycles += 5;
				}
				break;

				case 0xb5:
				{
					ZeroPageX_R();
					LDA();

					Cycles += 4;
				}
				break;

				case 0xb9:
				{
					AbsoluteY_R();
					LDA();

					Cycles += 4;
				}
				break;

				case 0xbd:
				{
					AbsoluteX_R();
					LDA();

					Cycles += 4;
				}
				break;
				#endregion

				#region LDX - Load X with memory
				case 0xa2:
				{
					Immediate();
					LDX();
					Cycles += 2;
				}
				break;
				case 0xa6:
				{
					ZeroPage_R();
					LDX();
					Cycles += 3;
				}
				break;
				case 0xb6:
				{
					ZeroPageY_R();
					LDX();
					Cycles += 4;
				}
				break;
				case 0xae:
				{
					Absolute_R();
					LDX();
					Cycles += 4;
				}
				break;
				case 0xbe:
				{
					AbsoluteY_R();
					LDX();
					Cycles += 4;
				}
				break;
				#endregion

				#region LDY - Load Y with memory
				case 0xa0:
				{
					Immediate();
					LDY();

					Cycles += 2;
				}
				break;
				case 0xa4:
				{
					ZeroPage_R();
					LDY();
					Cycles += 3;
				}
				break;
				case 0xb4:
				{
					ZeroPageX_R();
					LDY();
					Cycles += 4;
				}
				break;
				case 0xac:
				{
					Absolute_R();
					LDY();
					Cycles += 4;
				}
				break;
				case 0xbc:
				{
					AbsoluteX_R();
					LDY();
					Cycles += 4;
				}
				break;
				#endregion

				#region LSR - Logical Shift Right
				case 0x4a:
				{

				}
				break;
				case 0x46:
				{

				}
				break;
				case 0x56:
				{

				}
				break;
				case 0x4e:
				{

				}
				break;
				case 0x5e:
				{

				}
				break;
				#endregion

				#region NOP - No OPeration
				case 0xea:
				{
					Cycles += 2;
				}
				break;
				#endregion

				#region ORA - Bitwise-OR A with Memory
				case 0x09:
				{

				}
				break;
				case 0x05:
				{

				}
				break;
				case 0x15:
				{

				}
				break;
				case 0x0d:
				{

				}
				break;
				case 0x1d:
				{

				}
				break;
				case 0x19:
				{

				}
				break;
				case 0x01:
				{

				}
				break;
				case 0x11:
				{

				}
				break;
				#endregion

				#region PHA - PusH A onto Stack
				case 0x48:
				{
					PushByte(A);

					Cycles += 3;
				}
				break;
				#endregion

				#region PHP - PusH P onto Stack
				case 0x08:
				{

				}
				break;
				#endregion

				#region PLA - PulL from Stack to A
				case 0x68:
				{
					A = PopByte();

					Cycles += 4;
				}
				break;
				#endregion

				#region PLP - PulL from Stack to P
				case 0x28:
				{

				}
				break;
				#endregion

				#region ROL - ROtate Left
				case 0x2a:
				{

				}
				break;
				case 0x26:
				{

				}
				break;
				case 0x36:
				{

				}
				break;
				case 0x2e:
				{

				}
				break;
				case 0x3e:
				{

				}
				break;
				#endregion

				#region ROR - ROtate Right
				case 0x6a:
				{

				}
				break;
				case 0x66:
				{

				}
				break;
				case 0x76:
				{

				}
				break;
				case 0x6e:
				{

				}
				break;
				case 0x7e:
				{

				}
				break;
				#endregion

				#region RTI - ReTurn from Interrupt
				case 0x40:
				{

				}
				break;
				#endregion

				#region RTS - ReTurn from Subroutine
				case 0x60:
				{
					PC = PopShort();
					Cycles += 6;
				}
				break;
				#endregion

				#region SBC - Subtract Memory from A with Borrow
				case 0xe9:
				{

				}
				break;
				case 0xe5:
				{

				}
				break;
				case 0xf5:
				{

				}
				break;
				case 0xed:
				{

				}
				break;
				case 0xfd:
				{

				}
				break;
				case 0xf9:
				{

				}
				break;
				case 0xe1:
				{

				}
				break;
				case 0xf1:
				{

				}
				break;
				#endregion

				#region SEC - Set Carry flag (P.C)
				case 0x38:
				{
					C = true;
					Cycles = 2;
				}
				break;
				#endregion

				#region SED - Set Binary Coded Decimal Flag (P.D)
				case 0xf8:
				{

				}
				break;
				#endregion

				#region SEI - Set Interrupt (disable) Flag (P.I)
				case 0x78:
				{
					I = false;
					Cycles += 2;
				}
				break;
				#endregion

				#region STA - Store A in Memory
				case 0x85:
				{
					ZeroPage_W();
					STA();
					Cycles += 3;
				}
				break;

				case 0x8d:
				{
					Absolute_W();
					STA();
					Cycles += 4;
				}
				break;

				case 0x95:
				{
					ZeroPageX_W();
					STA();
					Cycles += 4;
				}
				break;

				case 0x9d:
				{
					AbsoluteX_W();
					STA();
					Cycles += 4;
				}
				break;
				case 0x99:
				{
					AbsoluteY_W();
					STA();
					Cycles += 4;
				}
				break;
				case 0x81:
				{
					IndirectX_W();
					STA();
					Cycles += 6;
				}
				break;
				case 0x91:
				{
					IndirectY_W();
					STA();
					Cycles += 5;
				}
				break;
				#endregion

				#region STX - Store X in Memory
				case 0x86:
				{
					b = Memory.ReadByte(PC);
					PC++;

					Memory.WriteByte(b, X);

					Cycles += 3;
				}
				break;

				case 0x8e:
				{
					s = Memory.ReadShort(PC);
					PC += 2;

					Memory.WriteByte(s, X);

					Cycles += 4;
				}
				break;
				case 0x96:
				{

				}
				break;
				#endregion

				#region STY - Store Y in Memory
				case 0x84:
				{

				}
				break;
				case 0x94:
				{

				}
				break;
				case 0x8c:
				{

				}
				break;
				#endregion

				#region TAX - Transfert A to X
				case 0xaa:
				{
					X = A;

					N = A < 0;
					Z = X == 0;

					Cycles += 2;
				}
				break;
				#endregion

				#region TAY - Transfer A to Y
				case 0xa8:
				{

				}
				break;
				#endregion

				#region TSX - Transfer Stack Pointer to X
				case 0xba:
				{

				}
				break;
				#endregion

				#region TXA - Transfer X to A
				case 0x8a:
				{
					TXA();
					Cycles += 2;
				}
				break;
				#endregion

				#region TXS - Transfer X to Stack Pointer
				case 0x9a:
				{
					TXS();
					Cycles += 2;
				}
				break;
				#endregion

				#region TYA - Transfer Y to A
				case 0x98:
				{
					TYA();
					Cycles += 2;
				}
				break;
				#endregion

				default:
				{

				}
				break;
			}
		}

		#region Instructions

		void ADC()
		{
			s = (ushort)(A + M + (byte)(C ? 1 : 0));

			V = CheckBit(A, 7) != CheckBit(s, 7);
			N = CheckBit(A, 7);
			Z = (s & 0xff) == 0;
			C = (s >> 0x8) != 0;

			A = (byte)(s & 0xff);
		}
		void AHX()
		{

		}
		void ALR() { }
		void ANC() { }
		void AND()
		{
			A &= (byte)M;
		}
		void ARR() { }
		void AXS() { }
		void ASL() { }
		void BIT() { }
		void BRK()
		{
			PushShort(PC);
			PushShort(P);

			PC = Memory.ReadShort(0xFFFE);
			I = true;
		}
		void CMP() { }
		void CPX() { }
		void CPY() { }
		void DCP() { }
		void DEC() { }
		void DEY() { }
		void DEX() { }
		void EOR() { }
		void INC() { }
		void INX() { }
		void ISC() { }
		void JMP() { }
		void JSR() { }
		void LAR() { }
		void LAX() { }
		void LDA()
		{
			A = (byte)M;
		}
		void LDX()
		{
			X = (byte)M;
		}
		void LDY()
		{
			Y = (byte)M;
		}
		void LSR() { }
		void ORA() { }
		void PHA() { }
		void PHP() { }
		void PLA() { }
		void PLP() { }
		void RLA() { }
		void ROL() { }
		void ROR() { }
		void RRA() { }
		void RTI() { }
		void RTS() { }
		void SAX() { }
		void SBC() { }
		void SHX() { }
		void SHY() { }
		void SLO() { }
		void SRE() { }
		void STA()
		{
			Memory.WriteByte(M, A);
		}
		void STX()
		{
			Memory.WriteByte(M, X);
		}
		void STY() { }
		void TAX() { }
		void TAY() { }
		void TSX() { }
		void TXA()
		{
			A = X;
		}
		void TXS()
		{
			PushByte(X);
		}
		void TYA()
		{
			A = Y;
		}
		void XAA() { }
		void XAS() { }

		#endregion

		#region Addressing Modes

		// http://www.atariarchives.org/mlb/chapter4.php

		/// <summary>
		/// "$xxxx"
		/// </summary>
		void Absolute_R()
		{
			s = Memory.ReadShort(PC);
			PC += 2;
			M = Memory.ReadByte(s);
		}
		/// <summary>
		/// "$xxxx"
		/// </summary>
		void Absolute_W()
		{
			M = Memory.ReadShort(PC);
			PC += 2;
		}


		/// <summary>
		/// "$xxxx, X"
		/// </summary>
		void AbsoluteX_R()
		{
			s = Memory.ReadShort(PC);
			PC += 2;
			M = Memory.ReadByte(s + X);
		}
		/// <summary>
		/// "$xxxx, X"
		/// </summary>
		void AbsoluteX_W()
		{
			s = Memory.ReadShort(PC);
			PC += 2;
			M = (ushort)(s + X);
		}


		/// <summary>
		/// "Abs, Y"
		/// </summary>
		void AbsoluteY_R()
		{
			s = Memory.ReadShort(PC);
			PC += 2;
			M = Memory.ReadByte(s + Y);
		}
		/// <summary>
		/// "Abs, Y"
		/// </summary>
		void AbsoluteY_W()
		{
			s = Memory.ReadShort(PC);
			PC += 2;
			M = (ushort)(s + Y);
		}


		/// <summary>
		/// "($xx, X)"
		/// </summary>
		void IndirectX_R()
		{
			b = Memory.ReadByte(PC++);
			s = Memory.ReadShort(s + X);
			M = Memory.ReadByte(s);
		}
		/// <summary>
		/// "($xx, X)"
		/// </summary>
		void IndirectX_W()
		{
			b = Memory.ReadByte(PC++);
			M = Memory.ReadShort(s + X);
		}


		/// <summary>
		/// "($xx), Y"
		/// </summary>
		void IndirectY_R()
		{
			b = Memory.ReadByte(PC++);
			s = Memory.ReadShort(b);

			M = Memory.ReadByte(s + Y);
		}
		/// <summary>
		/// "($xx), Y"
		/// </summary>
		void IndirectY_W()
		{
			b = Memory.ReadByte(PC++);
			s = Memory.ReadShort(b);

			M = (ushort)(s + Y);
		}


		/// <summary>
		/// "Immediate"
		/// </summary>
		void Immediate()
		{
			M = Memory.ReadByte(PC++);
		}


		/// <summary>
		/// ""
		/// </summary>
		void Implied() { }


		/// <summary>
		/// "$xx"
		/// </summary>
		void ZeroPage_R()
		{
			b = Memory.ReadByte(PC++);
			M = Memory.ReadByte(b);
		}
		/// <summary>
		/// "$xx"
		/// </summary>
		void ZeroPage_W()
		{
			M = Memory.ReadByte(PC++);
		}


		/// <summary>
		/// "$xx, X"
		/// </summary>
		void ZeroPageX_R()
		{
			b = Memory.ReadByte(PC++);
			M = Memory.ReadByte(b + X);
		}
		/// <summary>
		/// "$xx, X"
		/// </summary>
		void ZeroPageX_W()
		{
			b = Memory.ReadByte(PC++);
			M = (byte)(b + X);
		}


		/// <summary>
		/// "$xx, Y"
		/// </summary>
		void ZeroPageY_R()
		{
			b = Memory.ReadByte(PC++);
			M = Memory.ReadByte(b + Y);
		}
		/// <summary>
		/// "$xx, Y"
		/// </summary>
		void ZeroPageY_W()
		{
			b = Memory.ReadByte(PC++);
			M = (byte)(b + Y);
		}

		#endregion


		#region Stack operations

		/// <summary>
		/// Pushes a value on the stack
		/// </summary>
		/// <param name="val"></param>
		void PushByte(byte val)
		{
			Memory.WriteByte(0x100 + SP--, val);
		}


		/// <summary>
		/// Pops a value from the stack
		/// </summary>
		/// <returns></returns>
		byte PopByte()
		{
			return Memory.ReadByte(0x100 + ++SP);
		}



		/// <summary>
		/// Pushes a value on the stack
		/// </summary>
		/// <param name="val"></param>
		void PushShort(ushort val)
		{
			byte l = (byte)(val & 0xFF);
			byte h = (byte)((val & 0xFF00) >> 8);

			PushByte(h);
			PushByte(l);
		}


		/// <summary>
		/// Pops a value from the stack
		/// </summary>
		/// <returns></returns>
		ushort PopShort()
		{
			byte l = PopByte();
			byte h = PopByte();

			return (ushort)(l | h << 8);
		}

		#endregion


		#region Registers

		/// <summary>
		/// Accumulator
		/// </summary>
		public byte A
		{
			get
			{
				return _a;
			}
			set
			{
				Z = value == 0;
				N = CheckBit(value, 7);

				_a = value;
			}
		}
		byte _a;

		/// <summary>
		/// Index Register X
		/// </summary>
		public byte X
		{
			get
			{
				return _x;
			}
			set
			{
				Z = value == 0;
				N = CheckBit(value, 7);

				_x = value;
			}
		}
		byte _x;

		/// <summary>
		/// Index Register Y
		/// </summary>
		public byte Y
		{
			get
			{
				return _y;
			}
			set
			{
				Z = value == 0;
				N = CheckBit(value, 7);

				_y = value;
			}
		}
		byte _y;


		/// <summary>
		/// Stack Pointer [0x0100-0x01FF]
		/// </summary>
		public byte SP { get; set; }


		/// <summary>
		/// Program Counter
		/// </summary>
		public ushort PC { get; set; }


		/// <summary>
		/// Processor Flag
		/// 1) Carry flag        - Set if the last instruction resulted in an over or underflow. Used for arithmetic on numbers larger than one byte, where the next instruction is carry-flag aware.
		/// 2) Zero flag         - Set if the last instruction resulted in a value of 0
		/// 3) Interrupt Disable - Set to disable responding to maskable interrupts
		/// 4) Decimal Mode      - Set to enable BCD mode. This doesn't affect the 2A03 so flipping this value doesn't do anything.
		/// 5) Break Command     - Set to indicate a `BRK` instruction was executed
		/// 6) Unused bit
		/// 7) Overflow flag     - Set when an invalid two's complement number is the result of an operation. An example is adding 2 positive numbers which results in the sign bit being set, making the result a negative.
		/// 8) Negative flag     - Set if the number is negative, determined by checking the sign bit (7th bit)
		/// </summary>
		public byte P { get; private set; }


		/// <summary>
		/// Carry flag
		/// </summary>
		public bool C
		{
			get
			{
				return CheckBit(P, 0);
			}
			set
			{
				P = value ? SetBit(P, 0) : ClearBit(P, 0);
			}
		}


		/// <summary>
		/// Zero flag
		/// </summary>
		public bool Z
		{
			get
			{
				return CheckBit(P, 1);
			}
			set
			{
				P = value ? SetBit(P, 1) : ClearBit(P, 1);
			}
		}

		/// <summary>
		/// Interrupt Disable
		/// </summary>
		public bool I
		{
			get
			{
				return CheckBit(P, 2);
			}
			set
			{
				P = value ? SetBit(P, 2) : ClearBit(P, 2);
			}
		}

		/// <summary>
		/// Decimal Mode
		/// </summary>
		public bool D
		{
			get
			{
				return CheckBit(P, 3);
			}
			set
			{
				P = value ? SetBit(P, 3) : ClearBit(P, 3);
			}
		}

		/// <summary>
		/// Break Command
		/// </summary>
		public bool B
		{
			get
			{
				return CheckBit(P, 4);
			}
			set
			{
				P = value ? SetBit(P, 4) : ClearBit(P, 4);
			}
		}

		/// <summary>
		/// Overflow flag
		/// </summary>
		public bool V
		{
			get
			{
				return CheckBit(P, 6);
			}
			set
			{
				P = value ? SetBit(P, 6) : ClearBit(P, 6);
			}
		}

		/// <summary>
		/// Negative flag
		/// </summary>
		public bool N
		{
			get
			{
				return CheckBit(P, 7);
			}
			set
			{
				P = value ? SetBit(P, 7) : ClearBit(P, 7);
			}
		}








		/// <summary>
		/// Checks if a bit is set
		/// </summary>
		/// <param name="b"></param>
		/// <param name="pos"></param>
		/// <returns></returns>
		private bool CheckBit(uint b, byte pos)
		{
			return (b & (1 << pos)) != 0;
		}

		/// <summary>
		/// Sets a bit 
		/// </summary>
		/// <param name="b"></param>
		/// <param name="pos"></param>
		/// <returns></returns>
		private byte SetBit(byte b, byte pos)
		{
			return (byte)(b | (1 << pos));
		}

		/// <summary>
		/// Clears a bit 
		/// </summary>
		/// <param name="b"></param>
		/// <param name="pos"></param>
		/// <returns></returns>
		private byte ClearBit(uint b, byte pos)
		{
			byte mask = (byte)(1 << pos);
			return (byte)(b & ~mask);
		}
		#endregion


		#region Vectors

		/// <summary>
		/// The Non-Maskable Interrupt (0xFFFA)
		/// </summary>
		ushort NMIVector
		{
			get
			{
				return Memory.ReadShort(0xFFFA);
			}
			set
			{
				Memory.WriteShort(0xFFFA, value);
			}
		}

		/// <summary>
		/// Reset Vector ($FFFC)
		/// </summary>
		ushort ResetVector
		{
			get
			{
				return Memory.ReadShort(0xfffc);
			}
			set
			{
				Memory.WriteShort(0xfffc, value);
			}
		}

		/// <summary>
		/// the IRQ/BRK Vector  ($FFFE)
		/// </summary>
		ushort IRQVector
		{
			get
			{
				return Memory.ReadShort(0xfffe);
			}
			set
			{
				Memory.WriteShort(0xfffe, value);
			}
		}

		#endregion


		#region Variables

		/// <summary>
		/// Cycles
		/// </summary>
		uint Cycles;

		/// <summary>
		/// Temp operators
		/// </summary>
		ushort M;
		byte b;
		sbyte sb;
		ushort s;



		/// <summary>
		/// Current opcode
		/// </summary>
		byte OpCode;

		/// <summary>
		/// 
		/// </summary>
		Memory Memory;

		#endregion
	}
}
