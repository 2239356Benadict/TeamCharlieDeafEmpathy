# HearUs
### Description: 

![alt text](https://github.com/2239356Benadict/Assignment1/blob/main/Reception.png)

<p align="justify">
HearUs enhance the users empathy through showing the struggles and anxiety deaf people face when doing something that might seem simple to us for example visiting the doctors surgery to voice a problem they may have. The journey will showcase the struggle of health professionals wearing masks and how this may cause issues for the deaf person, for example trying to communicate to the receptionist to say who they are and that they have arrived for their appointment. Wearing masks restricts a deaf persons communication especially as many rely on lip reading, when health professionals are asked to pull their mask down in order to aid the deaf person they are often faced with an ethical issue of breaching health and safety regulations to help the deaf person or to deny the deaf person help. We can also to show the anxiety levels of deaf patients whilst waiting to be called into the doctors room they are unsure of how they are going to be made aware that it is their turn for an appointment, plus added stress on top of that including the issues that arise when the interpreter is late or has not been booked properly resulting in the deaf person having to go into an appointment alone knowing that they aren’t going to have the communication they rely on. Many deaf people leave these situations often feeling confused, deflated and angry with the health system and this is what we have to try and show through our VR application. 

![alt text](https://github.com/2239356Benadict/Assignment1/blob/main/Doc.png)

### Video
[<img src="https://github.com/2239356Benadict/Assignment1/blob/main/P1%20View.png" width="1000" height="" />](https://youtu.be/DCJpuyLStBI)

### Main Challenges Demonstrated 
1.	Interactions with receptionists without interpreter.
2.	The anxiety level of the deaf patients in the waiting room
3.	Interpreter is late or doesn't show up to appointment at all 
4.	Issues communicating with the doctor due to them not being deaf aware trained  









# Unity Settings

Project made with Unity 2021.3.17f

Changes from default Unity project with Android build target:  

Packages:  
Installed XR Plug-in Management. Quest 2 
Installed Oculus XR Plugin  
Installed XR Interaction Toolkit version 2.3.0 pre.1  

URP Samples imported (includes useful blob shadow shader)  

Quality Settings:  
Custom Quality profiles  for Quest 2  
Vsync disabled  
Anisotropic Textures set to Per Texture.  
Shadowmask Mode set to Shadowmask  
LOD Bias set to 0.7  
Skin Weights set to 2 Bones  

Player Settings:  
Auto Graphics API disabled, set to OpenGL ES 3.0  
Texture Compression format set to ATSC  
Minimum API Level set to Android 10.0 (API Level 29)  
Lightmap encoding set to High Quality  
HDR Cubemap encoding set to High Quality  
Use Incremental GC enabled 
Scripting Backend set to IL2CPP  
IL2CPP Code generation set to Faster (smaller) builds *Change this to Faster runtime for release build  
Target Architecture set to Arm64  
Active Input Handling set to Both  
Optimize Mesh Data enabled   

Physics Settings:  
Reuse Collision Callbacks enabled  
Default Max Angular Speed set to 7  

Time Settings:  
Maximum Allowed Timestep set to 0.0138 (for 72 Hz)  

URP Renderer Settings:  
Shadows – Transparent Receive Shadows disabled   

URP Pipeline asset settings for Quest 2: (minor differences for Quest 1 and Quest Pro)  
Disable Terrain Holes  
Main Light – Cast Shadows disabled  
Additional Lights set to Per Pixel  

Notes:  
Adjust URP shadow settings according to the needs of your game/app.   
For release builds enable Low Overhead Mode under Oculus XR Plug-in Management options.  
