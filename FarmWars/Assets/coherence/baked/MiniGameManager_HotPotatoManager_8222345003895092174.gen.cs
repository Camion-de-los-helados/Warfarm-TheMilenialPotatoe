// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using Coherence.ProtocolDef;
	using Coherence.Serializer;
	using Coherence.SimulationFrame;
	using Coherence.Entity;
	using Coherence.Utils;
	using Coherence.Brook;
	using Coherence.Toolkit;
	using UnityEngine;

	public struct MiniGameManager_HotPotatoManager_8222345003895092174 : ICoherenceComponentData
	{
		public float Timer;
		public int CurrentPlayer;
		public float MaxTime;

		public override string ToString()
		{
			return $"MiniGameManager_HotPotatoManager_8222345003895092174(Timer: {Timer}, CurrentPlayer: {CurrentPlayer}, MaxTime: {MaxTime})";
		}

		public uint GetComponentType() => Definition.InternalMiniGameManager_HotPotatoManager_8222345003895092174;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;
	
		private static readonly int _CurrentPlayer_Min = -2147483648;
		private static readonly int _CurrentPlayer_Max = 2147483647;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (MiniGameManager_HotPotatoManager_8222345003895092174)data;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				Timer = other.Timer;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				CurrentPlayer = other.CurrentPlayer;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				MaxTime = other.MaxTime;
			}
			mask >>= 1;
			return this;
		}

		public static void Serialize(MiniGameManager_HotPotatoManager_8222345003895092174 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteFloat(data.Timer, FloatMeta.NoCompression());
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.CurrentPlayer, _CurrentPlayer_Min, _CurrentPlayer_Max, "MiniGameManager_HotPotatoManager_8222345003895092174.CurrentPlayer");
				data.CurrentPlayer = Coherence.Utils.Bounds.Clamp(data.CurrentPlayer, _CurrentPlayer_Min, _CurrentPlayer_Max);
				bitStream.WriteIntegerRange(data.CurrentPlayer, 32, -2147483648);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteFloat(data.MaxTime, FloatMeta.NoCompression());
			}
			mask >>= 1;
		}

		public static (MiniGameManager_HotPotatoManager_8222345003895092174, uint, uint?) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new MiniGameManager_HotPotatoManager_8222345003895092174();
	
			if (bitStream.ReadMask())
			{
				val.Timer = bitStream.ReadFloat(FloatMeta.NoCompression());
				mask |= 0b00000000000000000000000000000001;
			}
			if (bitStream.ReadMask())
			{
				val.CurrentPlayer = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000000000000000000010;
			}
			if (bitStream.ReadMask())
			{
				val.MaxTime = bitStream.ReadFloat(FloatMeta.NoCompression());
				mask |= 0b00000000000000000000000000000100;
			}
			return (val, mask, null);
		}
		public static (MiniGameManager_HotPotatoManager_8222345003895092174, uint, uint?) DeserializeArchetypeMiniGameManager_759334206ec3a2d46b848ec8d2431208_MiniGameManager_HotPotatoManager_8222345003895092174_LOD0(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new MiniGameManager_HotPotatoManager_8222345003895092174();
			if (bitStream.ReadMask())
			{
				val.Timer = bitStream.ReadFloat(FloatMeta.NoCompression());
				mask |= 0b00000000000000000000000000000001;
			}
			if (bitStream.ReadMask())
			{
				val.CurrentPlayer = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000000000000000000010;
			}
			if (bitStream.ReadMask())
			{
				val.MaxTime = bitStream.ReadFloat(FloatMeta.NoCompression());
				mask |= 0b00000000000000000000000000000100;
			}

			return (val, mask, 0);
		}

		/// <summary>
		/// Resets byte array references to the local array instance that is kept in the lastSentData.
		/// If the array content has changed but remains of same length, the new content is copied into the local array instance.
		/// If the array length has changed, the array is cloned and overwrites the local instance.
		/// If the array has not changed, the reference is reset to the local array instance.
		/// Otherwise, changes to other fields on the component might cause the local array instance reference to become permanently lost.
		/// </summary>
		public void ResetByteArrays(ICoherenceComponentData lastSent, uint mask)
		{
			var last = lastSent as MiniGameManager_HotPotatoManager_8222345003895092174?;
	
		}
	}
}