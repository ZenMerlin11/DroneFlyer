# Drone Flyer Prototype
This is a unity prototype for a drone flying game.
Unity version 2017.1
Workflow: [Git-flow](http://nvie.com/posts/a-successful-git-branching-model/)

## Project Direction Ideas
- Canyon Racing w/ stationary or mobile obstacles
- Combat w/ Auto Aim and/or targetting assitance
- Combat w/ two player "warthog" drone: one drives, one shoots
- RC Drones, or full scale futuristic VTOL aircraft
- Prop driven quadcopter or jet driven with afterburners

## Cloning the Repository
This project uses Git LFS to track large binary assets. To clone the repository follow the below directions:

1. Install [Git LFS](https://git-lfs.github.com/)

2. Prepare Project Folder
    - Create an empty Unity project
    - Close Unity
    - Delete the `ProjectSetting` folder
3. Prepare the Git repo
    - Run `git init` to make the project a git repo
    - Run `git remote add origin https://github.com/ZenMerlin11/DroneFlyer.git` to add the remote repo
    - Run `git pull origin master` to pull origin/master to the local branch
    - Run `git branch develop` to create a new local branch develop
    - Run `git checkout develop` to switch to branch develop
    - Run `git pull origin develop` to pull origin/develop into the local branch `develop`

4. Add `.gitconfig` file for your system OR configure your Git client to use Unity's Smart Merge (see the [Unity Manual Page](http://docs.unity3d.com/Manual/SmartMerge.html) for further instructions)
    - Note: the `.gitconfig` file for a 64 bit Windows install is included in this repository for convenience since it is assumed all collaborators will be using this system. If using a different system, you will need to edit your .gitconfig file separately and ensure you do not add the file when making commits.

5. Open the project in Unity and begin work.