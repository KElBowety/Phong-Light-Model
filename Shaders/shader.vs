#version 330

layout (location = 0) in vec3 pos;
layout (location = 1) in vec2 tex;
layout (location = 2) in vec3 normal;

out vec4 vCol;
out vec2 TexCoord;
out vec3 normalInterp;
out vec3 vertPos;

uniform mat4 model;
uniform mat4 projection;
uniform mat4 view;
uniform mat4 normalMatrix;

void main()
{	
	vec4 vertPos4 = model * vec4(pos, 1.0);
  	vertPos = vec3(vertPos4) / vertPos4.w;
	gl_Position = projection * view * model * vec4(pos, 1.0);
	vCol = vec4(clamp(pos, 0.0f, 1.0f), 1.0f);
	normalInterp = vec3(normalMatrix * vec4(normal, 0.0));
	TexCoord = tex;
}