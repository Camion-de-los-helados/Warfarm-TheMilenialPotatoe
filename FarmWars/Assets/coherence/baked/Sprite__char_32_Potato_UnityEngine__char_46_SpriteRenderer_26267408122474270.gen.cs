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

	public struct Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270 : ICoherenceComponentData
	{
		public Vector2 size;
		public float adaptiveModeThreshold;
		public Color color;
		public bool flipX;
		public bool flipY;
		public SerializeEntityID lightProbeAnchor;
		public bool castShadows;
		public bool motionVectors;
		public bool useLightProbes;
		public bool enabled;
		public bool receiveShadows;
		public bool forceRenderingOff;
		public bool staticShadowCaster;
		public uint renderingLayerMask;
		public int rendererPriority;
		public string sortingLayerName;
		public int sortingLayerID;
		public int sortingOrder;
		public bool allowOcclusionWhenDynamic;
		public SerializeEntityID lightProbeProxyVolumeOverride;
		public SerializeEntityID probeAnchor;
		public int lightmapIndex;
		public int realtimeLightmapIndex;

		public override string ToString()
		{
			return $"Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270(size: {size}, adaptiveModeThreshold: {adaptiveModeThreshold}, color: {color}, flipX: {flipX}, flipY: {flipY}, lightProbeAnchor: {lightProbeAnchor}, castShadows: {castShadows}, motionVectors: {motionVectors}, useLightProbes: {useLightProbes}, enabled: {enabled}, receiveShadows: {receiveShadows}, forceRenderingOff: {forceRenderingOff}, staticShadowCaster: {staticShadowCaster}, renderingLayerMask: {renderingLayerMask}, rendererPriority: {rendererPriority}, sortingLayerName: {sortingLayerName}, sortingLayerID: {sortingLayerID}, sortingOrder: {sortingOrder}, allowOcclusionWhenDynamic: {allowOcclusionWhenDynamic}, lightProbeProxyVolumeOverride: {lightProbeProxyVolumeOverride}, probeAnchor: {probeAnchor}, lightmapIndex: {lightmapIndex}, realtimeLightmapIndex: {realtimeLightmapIndex})";
		}

		public uint GetComponentType() => Definition.InternalSprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;
	
		private static readonly uint _renderingLayerMask_Min = 0;
		private static readonly uint _renderingLayerMask_Max = 4294967295;
		private static readonly int _rendererPriority_Min = -2147483648;
		private static readonly int _rendererPriority_Max = 2147483647;
		private static readonly int _sortingLayerID_Min = -2147483648;
		private static readonly int _sortingLayerID_Max = 2147483647;
		private static readonly int _sortingOrder_Min = -2147483648;
		private static readonly int _sortingOrder_Max = 2147483647;
		private static readonly int _lightmapIndex_Min = -2147483648;
		private static readonly int _lightmapIndex_Max = 2147483647;
		private static readonly int _realtimeLightmapIndex_Min = -2147483648;
		private static readonly int _realtimeLightmapIndex_Max = 2147483647;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270)data;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				size = other.size;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				adaptiveModeThreshold = other.adaptiveModeThreshold;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				color = other.color;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				flipX = other.flipX;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				flipY = other.flipY;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				lightProbeAnchor = other.lightProbeAnchor;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				castShadows = other.castShadows;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				motionVectors = other.motionVectors;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				useLightProbes = other.useLightProbes;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				enabled = other.enabled;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				receiveShadows = other.receiveShadows;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				forceRenderingOff = other.forceRenderingOff;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				staticShadowCaster = other.staticShadowCaster;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				renderingLayerMask = other.renderingLayerMask;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				rendererPriority = other.rendererPriority;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				sortingLayerName = other.sortingLayerName;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				sortingLayerID = other.sortingLayerID;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				sortingOrder = other.sortingOrder;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				allowOcclusionWhenDynamic = other.allowOcclusionWhenDynamic;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				lightProbeProxyVolumeOverride = other.lightProbeProxyVolumeOverride;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				probeAnchor = other.probeAnchor;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				lightmapIndex = other.lightmapIndex;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				realtimeLightmapIndex = other.realtimeLightmapIndex;
			}
			mask >>= 1;
			return this;
		}

		public static void Serialize(Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteVector2((data.size.ToCoreVector2()), FloatMeta.NoCompression());
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteFloat(data.adaptiveModeThreshold, FloatMeta.NoCompression());
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteColor((data.color.ToCoreColor()), FloatMeta.ForFixedPoint(0, 1, 2.3283064370807973753052522170037E-10));
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteBool(data.flipX);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteBool(data.flipY);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteEntity(data.lightProbeAnchor);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteBool(data.castShadows);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteBool(data.motionVectors);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteBool(data.useLightProbes);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteBool(data.enabled);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteBool(data.receiveShadows);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteBool(data.forceRenderingOff);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteBool(data.staticShadowCaster);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.renderingLayerMask, _renderingLayerMask_Min, _renderingLayerMask_Max, "Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270.renderingLayerMask");
				data.renderingLayerMask = Coherence.Utils.Bounds.Clamp(data.renderingLayerMask, _renderingLayerMask_Min, _renderingLayerMask_Max);
				bitStream.WriteUIntegerRange(data.renderingLayerMask, 32, 0);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.rendererPriority, _rendererPriority_Min, _rendererPriority_Max, "Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270.rendererPriority");
				data.rendererPriority = Coherence.Utils.Bounds.Clamp(data.rendererPriority, _rendererPriority_Min, _rendererPriority_Max);
				bitStream.WriteIntegerRange(data.rendererPriority, 32, -2147483648);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteShortString(data.sortingLayerName);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.sortingLayerID, _sortingLayerID_Min, _sortingLayerID_Max, "Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270.sortingLayerID");
				data.sortingLayerID = Coherence.Utils.Bounds.Clamp(data.sortingLayerID, _sortingLayerID_Min, _sortingLayerID_Max);
				bitStream.WriteIntegerRange(data.sortingLayerID, 32, -2147483648);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.sortingOrder, _sortingOrder_Min, _sortingOrder_Max, "Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270.sortingOrder");
				data.sortingOrder = Coherence.Utils.Bounds.Clamp(data.sortingOrder, _sortingOrder_Min, _sortingOrder_Max);
				bitStream.WriteIntegerRange(data.sortingOrder, 32, -2147483648);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteBool(data.allowOcclusionWhenDynamic);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteEntity(data.lightProbeProxyVolumeOverride);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteEntity(data.probeAnchor);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.lightmapIndex, _lightmapIndex_Min, _lightmapIndex_Max, "Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270.lightmapIndex");
				data.lightmapIndex = Coherence.Utils.Bounds.Clamp(data.lightmapIndex, _lightmapIndex_Min, _lightmapIndex_Max);
				bitStream.WriteIntegerRange(data.lightmapIndex, 32, -2147483648);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.realtimeLightmapIndex, _realtimeLightmapIndex_Min, _realtimeLightmapIndex_Max, "Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270.realtimeLightmapIndex");
				data.realtimeLightmapIndex = Coherence.Utils.Bounds.Clamp(data.realtimeLightmapIndex, _realtimeLightmapIndex_Min, _realtimeLightmapIndex_Max);
				bitStream.WriteIntegerRange(data.realtimeLightmapIndex, 32, -2147483648);
			}
			mask >>= 1;
		}

		public static (Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270, uint, uint?) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270();
	
			if (bitStream.ReadMask())
			{
				val.size = (bitStream.ReadVector2(FloatMeta.NoCompression())).ToUnityVector2();
				mask |= 0b00000000000000000000000000000001;
			}
			if (bitStream.ReadMask())
			{
				val.adaptiveModeThreshold = bitStream.ReadFloat(FloatMeta.NoCompression());
				mask |= 0b00000000000000000000000000000010;
			}
			if (bitStream.ReadMask())
			{
				val.color = (bitStream.ReadColor(FloatMeta.ForFixedPoint(0, 1, 2.3283064370807973753052522170037E-10))).ToUnityColor();
				mask |= 0b00000000000000000000000000000100;
			}
			if (bitStream.ReadMask())
			{
				val.flipX = bitStream.ReadBool();
				mask |= 0b00000000000000000000000000001000;
			}
			if (bitStream.ReadMask())
			{
				val.flipY = bitStream.ReadBool();
				mask |= 0b00000000000000000000000000010000;
			}
			if (bitStream.ReadMask())
			{
				val.lightProbeAnchor = bitStream.ReadEntity();
				mask |= 0b00000000000000000000000000100000;
			}
			if (bitStream.ReadMask())
			{
				val.castShadows = bitStream.ReadBool();
				mask |= 0b00000000000000000000000001000000;
			}
			if (bitStream.ReadMask())
			{
				val.motionVectors = bitStream.ReadBool();
				mask |= 0b00000000000000000000000010000000;
			}
			if (bitStream.ReadMask())
			{
				val.useLightProbes = bitStream.ReadBool();
				mask |= 0b00000000000000000000000100000000;
			}
			if (bitStream.ReadMask())
			{
				val.enabled = bitStream.ReadBool();
				mask |= 0b00000000000000000000001000000000;
			}
			if (bitStream.ReadMask())
			{
				val.receiveShadows = bitStream.ReadBool();
				mask |= 0b00000000000000000000010000000000;
			}
			if (bitStream.ReadMask())
			{
				val.forceRenderingOff = bitStream.ReadBool();
				mask |= 0b00000000000000000000100000000000;
			}
			if (bitStream.ReadMask())
			{
				val.staticShadowCaster = bitStream.ReadBool();
				mask |= 0b00000000000000000001000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.renderingLayerMask = bitStream.ReadUIntegerRange(32, 0);
				mask |= 0b00000000000000000010000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.rendererPriority = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000000100000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.sortingLayerName = bitStream.ReadShortString();
				mask |= 0b00000000000000001000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.sortingLayerID = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000010000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.sortingOrder = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000100000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.allowOcclusionWhenDynamic = bitStream.ReadBool();
				mask |= 0b00000000000001000000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.lightProbeProxyVolumeOverride = bitStream.ReadEntity();
				mask |= 0b00000000000010000000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.probeAnchor = bitStream.ReadEntity();
				mask |= 0b00000000000100000000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.lightmapIndex = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000001000000000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.realtimeLightmapIndex = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000010000000000000000000000;
			}
			return (val, mask, null);
		}
		public static (Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270, uint, uint?) DeserializeArchetypeSprite__char_32_Potato_9695b90e9288dc943beda0d6f17570fe_Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270_LOD0(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270();
			if (bitStream.ReadMask())
			{
				val.size = (bitStream.ReadVector2(FloatMeta.NoCompression())).ToUnityVector2();
				mask |= 0b00000000000000000000000000000001;
			}
			if (bitStream.ReadMask())
			{
				val.adaptiveModeThreshold = bitStream.ReadFloat(FloatMeta.NoCompression());
				mask |= 0b00000000000000000000000000000010;
			}
			if (bitStream.ReadMask())
			{
				val.color = (bitStream.ReadColor(FloatMeta.ForFixedPoint(0, 1, 2.3283064370807973753052522170037E-10))).ToUnityColor();
				mask |= 0b00000000000000000000000000000100;
			}
			if (bitStream.ReadMask())
			{
				val.flipX = bitStream.ReadBool();
				mask |= 0b00000000000000000000000000001000;
			}
			if (bitStream.ReadMask())
			{
				val.flipY = bitStream.ReadBool();
				mask |= 0b00000000000000000000000000010000;
			}
			if (bitStream.ReadMask())
			{
				val.lightProbeAnchor = bitStream.ReadEntity();
				mask |= 0b00000000000000000000000000100000;
			}
			if (bitStream.ReadMask())
			{
				val.castShadows = bitStream.ReadBool();
				mask |= 0b00000000000000000000000001000000;
			}
			if (bitStream.ReadMask())
			{
				val.motionVectors = bitStream.ReadBool();
				mask |= 0b00000000000000000000000010000000;
			}
			if (bitStream.ReadMask())
			{
				val.useLightProbes = bitStream.ReadBool();
				mask |= 0b00000000000000000000000100000000;
			}
			if (bitStream.ReadMask())
			{
				val.enabled = bitStream.ReadBool();
				mask |= 0b00000000000000000000001000000000;
			}
			if (bitStream.ReadMask())
			{
				val.receiveShadows = bitStream.ReadBool();
				mask |= 0b00000000000000000000010000000000;
			}
			if (bitStream.ReadMask())
			{
				val.forceRenderingOff = bitStream.ReadBool();
				mask |= 0b00000000000000000000100000000000;
			}
			if (bitStream.ReadMask())
			{
				val.staticShadowCaster = bitStream.ReadBool();
				mask |= 0b00000000000000000001000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.renderingLayerMask = bitStream.ReadUIntegerRange(32, 0);
				mask |= 0b00000000000000000010000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.rendererPriority = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000000100000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.sortingLayerName = bitStream.ReadShortString();
				mask |= 0b00000000000000001000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.sortingLayerID = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000010000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.sortingOrder = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000100000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.allowOcclusionWhenDynamic = bitStream.ReadBool();
				mask |= 0b00000000000001000000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.lightProbeProxyVolumeOverride = bitStream.ReadEntity();
				mask |= 0b00000000000010000000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.probeAnchor = bitStream.ReadEntity();
				mask |= 0b00000000000100000000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.lightmapIndex = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000001000000000000000000000;
			}
			if (bitStream.ReadMask())
			{
				val.realtimeLightmapIndex = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000010000000000000000000000;
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
			var last = lastSent as Sprite__char_32_Potato_UnityEngine__char_46_SpriteRenderer_26267408122474270?;
	
		}
	}
}