#!/bin/zsh
cd Lectures/Lec04/ 
alias fslex="mono /Users/adrian/Documents/ITU/5_Semester/Programmer\ som\ data/PRDAT/fsharp/FsLex.exe --unicode"
alias fsyacc="mono /Users/adrian/Documents/ITU/5_Semester/Programmer\ som\ data/PRDAT/fsharp/fsyacc.exe"
rm -r FunPar.fs FunLex.fs
fsyacc --module FunPar FunPar.fsy
fslex --unicode FunLex.fsl
fsharpi -r ../../fsharp/FsLexYacc.Runtime.dll Fun/Absyn.fs Fun/FunPar.fs Fun/FunLex.fs Fun/Parse.fs TypedFun/TypedFun.fs



#fsyacc --module FunPar FunPar.fsy
#fslex --unicode FunLex.fsl
#fsharpi -r ../../../fsharp/FsLexYacc.Runtime.dll Absyn.fs FunPar.fs FunLex.fs Parse.fs Fun.fs ParseAndRun.fs TypeInference.fs