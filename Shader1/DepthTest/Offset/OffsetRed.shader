Shader "Hidden/OffsetRed"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        

        Pass
        {
			offset -1,-1
			
            Color(1,0,0,1)
        }
    }
}
