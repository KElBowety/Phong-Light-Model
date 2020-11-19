#version 330

in vec4 vCol;
in vec2 TexCoord;
in vec3 normalInterp;
in vec3 vertPos;

out vec4 colour;

uniform sampler2D theTexture;

void main()
{
	vec3 N = normalize(normalInterp);
  	vec3 L = normalize(vec3(0.5, -0.5, 0.8) - vertPos);

	float lambertian = max(dot(N, L), 0.0);
  	float specular = 0.0;
  	if(lambertian > 0.0) {
    		vec3 R = reflect(-L, N);      // Reflected light vector
    		vec3 V = normalize(-vertPos); // Vector to viewer
    		// Compute the specular term
    		float specAngle = max(dot(R, V), 0.0);
    		specular = pow(specAngle, 80);
  	}

	colour = vec4(vec3(0.023, 0.129, 0.435) +
                      lambertian * vec3(0.815, 0.243, 0.427)+
                      specular * vec3(1.0, 1.0, 1.0), 1.0);
	//colour = texture(theTexture, TexCoord);
}