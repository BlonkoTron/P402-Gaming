#ifndef CUSTOM_LIGHTING_INCLUDED
#define CUSTOM_LIGHTING_INCLUDED

#include "CustomLighting.hlsl"

void AdditionalLight_float(float3 WorldPos, int lightID, out float3 Direction, out float3 Color, out float Attenuation)
{
    Direction = normalize(float3(1.0f, 1.0f, 0)); // Default direction
    Color = float3(0.0f, 0.0f, 0.0f);             // Default color
    
#ifndef SHADERGRAPH_PREVIEW
    
    int lightCount = GetAdditionalLightsCount();
    if (lightID >= 0 && lightID < lightCount) // Ensure lightID is valid
    {
        Light light = GetAdditionalLight(lightID, WorldPos); // Retrieve light data
        Direction = light.direction;
        Color = light.color;
        
    }
   
#endif    
}
#endif
