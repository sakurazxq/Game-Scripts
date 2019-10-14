Shader "Hidden/TestVertex"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_TestColor("TestColor", Color) = (1,1,1,1)
    }
    SubShader
    {
 
        Pass
        {
            //Color (0,1,0,1)
			//Color[_TestColor]

			Material
			{
				Diffuse[_TestColor]
				//Ambient[_TestColor]
				//Specular[_TestColor]
			}

			Lighting on

			SeparateSpecular On
        }
    }
}
