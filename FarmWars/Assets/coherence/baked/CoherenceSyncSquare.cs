// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using Coherence.Toolkit;
	using Coherence.Toolkit.Bindings;
	using Coherence.Entity;
	using Coherence.ProtocolDef;
	using Coherence.Brook;
	using Coherence.Toolkit.Bindings.ValueBindings;
	using Coherence.Toolkit.Bindings.TransformBindings;
	using Coherence.Connection;
	using Coherence.Log;
	using Logger = Coherence.Log.Logger;
	using UnityEngine.Scripting;

	public class Binding_59eb3b3a74ef2544cbd0bb383d729383_5dd96aae_847e_4b12_9f40_5eb44feb4ed6 : Vector2Binding
	{
		private UnityEngine.SpriteRenderer CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (UnityEngine.SpriteRenderer)UnityComponent;
		}
		public override string CoherenceComponentName => "Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override Vector2 Value
		{
			get => (Vector2)(UnityEngine.Vector2)(CastedUnityComponent.size);
			set => CastedUnityComponent.size = (UnityEngine.Vector2)(value);
		}

		protected override Vector2 ReadComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250)coherenceComponent;
			return update.size;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250)coherenceComponent;
			update.size = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250();
		}
	}

	public class Binding_59eb3b3a74ef2544cbd0bb383d729383_33e09871_dcbc_415a_8e2b_ac57c1470cac : ColorBinding
	{
		private UnityEngine.SpriteRenderer CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (UnityEngine.SpriteRenderer)UnityComponent;
		}
		public override string CoherenceComponentName => "Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250";

		public override uint FieldMask => 0b00000000000000000000000000000010;

		public override Color Value
		{
			get => (Color)(UnityEngine.Color)(CastedUnityComponent.color);
			set => CastedUnityComponent.color = (UnityEngine.Color)(value);
		}

		protected override Color ReadComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250)coherenceComponent;
			return update.color;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250)coherenceComponent;
			update.color = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250();
		}
	}


	[Preserve]
	[AddComponentMenu("coherence/Baked/Baked 'Square' (auto assigned)")]
	[RequireComponent(typeof(CoherenceSync))]
	public class CoherenceSyncSquare : CoherenceSyncBaked
	{
		private CoherenceSync coherenceSync;
		private Logger logger;

		// Cached targets for commands

		private IClient client;
		private CoherenceMonoBridge monoBridge => coherenceSync.MonoBridge;

		protected void Awake()
		{
			coherenceSync = GetComponent<CoherenceSync>();
			coherenceSync.usingReflection = false;

			logger = coherenceSync.logger.With<CoherenceSyncSquare>();
			if (coherenceSync.TryGetBindingByGuid("5dd96aae-847e-4b12-9f40-5eb44feb4ed6", "size", out Binding InternalSquare_UnityEngine__char_46_SpriteRenderer_4692109573835368250_Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250_size))
			{
				var clone = new Binding_59eb3b3a74ef2544cbd0bb383d729383_5dd96aae_847e_4b12_9f40_5eb44feb4ed6();
				InternalSquare_UnityEngine__char_46_SpriteRenderer_4692109573835368250_Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250_size.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalSquare_UnityEngine__char_46_SpriteRenderer_4692109573835368250_Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250_size)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (UnityEngine.SpriteRenderer).size");
			}
			if (coherenceSync.TryGetBindingByGuid("33e09871-dcbc-415a-8e2b-ac57c1470cac", "color", out Binding InternalSquare_UnityEngine__char_46_SpriteRenderer_4692109573835368250_Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250_color))
			{
				var clone = new Binding_59eb3b3a74ef2544cbd0bb383d729383_33e09871_dcbc_415a_8e2b_ac57c1470cac();
				InternalSquare_UnityEngine__char_46_SpriteRenderer_4692109573835368250_Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250_color.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalSquare_UnityEngine__char_46_SpriteRenderer_4692109573835368250_Square_UnityEngine__char_46_SpriteRenderer_4692109573835368250_color)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (UnityEngine.SpriteRenderer).color");
			}
		}

		public override List<ICoherenceComponentData> CreateEntity()
		{
			if (coherenceSync.UsesLODsAtRuntime && (Archetypes.IndexForName.TryGetValue(coherenceSync.Archetype.ArchetypeName, out int archetypeIndex)))
			{
				var components = new List<ICoherenceComponentData>()
				{
					new ArchetypeComponent
					{
						index = archetypeIndex
					}
				};

				return components;
			}
			else
			{
				logger.Warning($"Unable to find archetype {coherenceSync.Archetype.ArchetypeName} in dictionary. Please, bake manually (coherence > Bake)");
			}

			return null;
		}

		public override void Initialize(CoherenceSync sync, IClient client)
		{
			if (coherenceSync == null)
			{
				coherenceSync = sync;
			}
			this.client = client;
		}

		public override void ReceiveCommand(IEntityCommand command)
		{
			switch(command)
			{
				default:
					logger.Warning($"[CoherenceSyncSquare] Unhandled command: {command.GetType()}.");
					break;
			}
		}
	}
}