#!/bin/bash
cd Lectures/Lec04/Fun/ 
alias fslex="mono /Users/deniz/Desktop/PRDAT/fsharp/fslex.exe --unicode"
alias fsyacc="mono /Users/deniz/Desktop/PRDAT/fsharp/fsyacc.exe"
rm -r FunPar.fs FunLex.fs
fsyacc --module FunPar FunPar.fsy
fslex --unicode FunLex.fsl
fsharpi -r ../../../fsharp/FsLexYacc.Runtime.dll Absyn.fs FunPar.fs FunLex.fs Parse.fs Fun.fs ParseAndRun.fs
open ParseAndRun;;