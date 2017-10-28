using System;
using UnityEditor.Graphing;
using UnityEngine;

namespace UnityEditor.ShaderGraph
{
    [Serializable]
    public class UVMaterialSlot : Vector2MaterialSlot, IMayRequireMeshUV
    {
        private UVChannel m_Channel = UVChannel.uv0;

        public UVChannel channel
        {
            get { return m_Channel; }
            set { m_Channel = value; }
        }

        public UVMaterialSlot(int slotId, string displayName, string shaderOutputName, UVChannel channel,
            ShaderStage shaderStage = ShaderStage.Dynamic, bool hidden = false)
            : base(slotId, displayName, shaderOutputName, SlotType.Input, Vector2.zero, shaderStage, hidden)
        {
            this.channel = channel;
        }

        public override string GetDefaultValue(GenerationMode generationMode)
        {
            return string.Format("{0}.xy", channel.GetUVName());
        }

        public bool RequiresMeshUV(UVChannel channel)
        {
            if (isConnected)
                return false;

            return m_Channel == channel;
        }
    }
}