# AGAR AGAR

Read [this](https://thoughtbot.com/blog/how-to-git-with-unity)

## Project Setup
- Clone this repo to create a local repo `git clone <link>`
- Check if this repo is added as a remote repo in your comp `git remote -v`
- If repo is not added as remote repo, meaning the above command does not show you anything type in `git remote add origin <link>`

## On Pushing New Changes 
- Always do a `git pull` or `git pull --rebase` before you make any changes
- On root dir `git add .`
- `git commit -m "<your message here(make it meaningful)>"`
- `git push`

## Features
- 3 Levels of Enemy AI
- 1 Minute to win the game

## ml-agent
### Attempt
- We tried to train a ml-agent using deep reinforcement learning with tensorflow. However, the Agar Agar Game environment is too complex for us to train the agent on our personal machines. 
### Future development
- It could be possible for us to simplify the scenario the ml-agent is trained in.
- Simplified scenario 1: Only generation of one food on the map - Train ml-agent to take shortest path to food
- Simplified scenario 2: Only generation of food on the map - Train ml-agent to find the most food
- Simplified scenario 3: Smaller Enemy - Train ml-agent to hunt small enemies
- Simplified scenario 4: Larger Enemy - Train ml-agent to avoid large enemies

## Bugs
- The pause menu layer is behind the actual game which may block the menu 
