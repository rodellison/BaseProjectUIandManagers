# Unity GameJam simple base project

A simple Unity project (setup for WebGL as default) meant to provide some core functionality for basic
Gamejam type games..

1. A Singleton GameManager (I know.. Singleton - boo, hiss) but for quick
gamejams, does the trick.
2. A UIManager which has a few basic Canvas UIs for The Title Screen, How-To-Play, a Settings screen
and some Win and Lose UIs.
3. A directory of Scriptable Objects that allow the overall game flow to be Event Based.  
    - [Unity 2017 talk by Ryan Hipple for Scriptable Object Architecture](https://www.youtube.com/watch?v=raQ3iHhE_Kk)
    - Create Scriptable Objects for Game Events, then attach the corresponding listeners to any/all game objects that should react to the Event.
4. An AudioMixer, with a few seperate controls for Master, Effects, and Music. The
**SettingsPause** UI mentioned above has a section for Audio controls with Sliders
that are preconfigured to send their data to the Audio Mixer.
5. PlayerPrefs for saving Audio Settings.

# How to use:
1. Clone/Open the project, and navigate to the Base Project folder, and load 
the _Managers.unity scene.. In your build settings, this should be scene 0.
2. Change the UI graphics to suit your needs for Title Screen, Win, Lose, Settings, etc.
