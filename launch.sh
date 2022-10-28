#!/bin/zsh
cd Lectures/Lec07/microC
#alias fslex="mono /Users/adrian/Documents/ITU/5_Semester/Programmer\ som\ data/PRDAT/fsharp/FsLex.exe --unicode"
#alias fsyacc="o /Users/adrian/Documents/ITU/5_Semester/Programmer\ som\ data/PRDAT/fsharp/fsyacc.exe"
alias fslex="mono /Users/deniz/Desktop/PRDAT/fsharp/fslex.exe --unicode"
alias fsyacc="mono /Users/deniz/Desktop/PRDAT/fsharp/fsyacc.exe"
rm -r CPar.fs CLex.fs
fslex --unicode CLex.fsl
fsyacc --module CPar CPar.fsy
fsharpi -r ../../../fsharp//FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs

