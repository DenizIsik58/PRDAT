#!/bin/zsh
cd Lectures/Lec07/Microc 
alias fslex="mono /Users/adrian/Documents/ITU/5_Semester/Programmer\ som\ data/PRDAT/fsharp/FsLex.exe --unicode"
alias fsyacc="mono /Users/adrian/Documents/ITU/5_Semester/Programmer\ som\ data/PRDAT/fsharp/fsyacc.exe"
rm -r CPar.fs CLex.fs
fslex --unicode CLex.fsl
fsyacc --module CPar CPar.fsy
fsharpi -r FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs LeMachine.fs Comp.fs ParseAndComp.fs   



#fsyacc --module FunPar FunPar.fsy
#fslex --unicode FunLex.fsl
#fsharpi -r ../../../fsharp/FsLexYacc.Runtime.dll Absyn.fs FunPar.fs FunLex.fs Parse.fs Fun.fs ParseAndRun.fs TypeInference.fs