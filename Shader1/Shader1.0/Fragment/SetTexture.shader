Shader "Custom/SetTexture"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_BlendTex("Blend", 2D) = "white" {}
    }
    SubShader
    {


        Pass
        {
            Color(1,0,0,1)
			SetTexture[_MainTex]
			{
				combine Texture
			}
			
			//SetTexture[_BlendTex]
			//{
				//combine Texture lerp(Previous) Previous
			//}

			SetTexture[_MainTex]
			{
				constantColor(1,0,0,1)
				combine Texture * Constant
			}
        }
    }
}
