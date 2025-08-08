# Git Commands Reference

A comprehensive guide to essential Git commands for version control.

## Table of Contents
- [Initial Setup](#initial-setup)
- [Repository Creation](#repository-creation)
- [Basic Workflow](#basic-workflow)
- [Branching](#branching)
- [Remote Repositories](#remote-repositories)
- [Viewing History](#viewing-history)
- [Undoing Changes](#undoing-changes)
- [Stashing](#stashing)
- [Advanced Commands](#advanced-commands)

## Initial Setup

Configure Git with your identity:
```bash
git config --global user.name "Your Name"
git config --global user.email "your.email@example.com"
```

Check your configuration:
```bash
git config --list
```

## Repository Creation

Initialize a new Git repository:
```bash
git init
```

Clone an existing repository:
```bash
git clone <repository-url>
git clone https://github.com/user/repo.git
```

## Basic Workflow

Check repository status:
```bash
git status
```

Add files to staging area:
```bash
git add <filename>          # Add specific file
git add .                   # Add all files
git add *.js                # Add all JavaScript files
```

Commit changes:
```bash
git commit -m "Commit message"
git commit -am "Add and commit in one step"  # For tracked files only
```

View differences:
```bash
git diff                    # Unstaged changes
git diff --staged           # Staged changes
git diff HEAD               # All changes since last commit
```

## Branching

List branches:
```bash
git branch                  # Local branches
git branch -r               # Remote branches
git branch -a               # All branches
```

Create and switch branches:
```bash
git branch <branch-name>    # Create branch
git checkout <branch-name>  # Switch to branch
git checkout -b <branch-name>  # Create and switch to branch
git switch <branch-name>    # Modern way to switch branches
git switch -c <branch-name> # Modern way to create and switch
```

Merge branches:
```bash
git merge <branch-name>     # Merge branch into current branch
git merge --no-ff <branch-name>  # Merge with merge commit
```

Delete branches:
```bash
git branch -d <branch-name>    # Delete merged branch
git branch -D <branch-name>    # Force delete branch
```

## Remote Repositories

Add remote repository:
```bash
git remote add origin <repository-url>
```

View remotes:
```bash
git remote -v
```

Fetch and pull changes:
```bash
git fetch                   # Download changes without merging
git pull                    # Fetch and merge changes
git pull origin <branch-name>  # Pull from specific branch
```

Push changes:
```bash
git push                    # Push to default remote/branch
git push origin <branch-name>  # Push to specific branch
git push -u origin <branch-name>  # Push and set upstream
git push --all              # Push all branches
```

## Viewing History

View commit history:
```bash
git log                     # Full commit history
git log --oneline           # Condensed history
git log --graph             # Visual branch history
git log --author="Name"     # Filter by author
git log --since="2 weeks ago"  # Filter by date
```

Show specific commit:
```bash
git show <commit-hash>      # Show commit details
git show HEAD               # Show latest commit
git show HEAD~1             # Show previous commit
```

## Undoing Changes

Discard unstaged changes:
```bash
git checkout -- <filename>    # Discard changes to specific file
git checkout -- .             # Discard all unstaged changes
git restore <filename>         # Modern way to discard changes
```

Unstage files:
```bash
git reset HEAD <filename>      # Unstage specific file
git reset                      # Unstage all files
git restore --staged <filename>  # Modern way to unstage
```

Undo commits:
```bash
git reset --soft HEAD~1       # Undo commit, keep changes staged
git reset --mixed HEAD~1      # Undo commit, keep changes unstaged
git reset --hard HEAD~1       # Undo commit, discard changes
git revert <commit-hash>       # Create new commit that undoes changes
```

## Stashing

Save work temporarily:
```bash
git stash                   # Stash current changes
git stash push -m "Message" # Stash with message
git stash -u                # Include untracked files
```

Manage stashes:
```bash
git stash list              # List all stashes
git stash show              # Show stash contents
git stash pop               # Apply and remove latest stash
git stash apply             # Apply stash without removing
git stash drop              # Delete latest stash
git stash clear             # Delete all stashes
```

## Advanced Commands

Interactive rebase:
```bash
git rebase -i HEAD~3        # Interactive rebase last 3 commits
```

Cherry-pick commits:
```bash
git cherry-pick <c
