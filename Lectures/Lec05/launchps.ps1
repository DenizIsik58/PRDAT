cd ..
cd ..
cd Lectures/Lec05/ 
rm -r FunPar.fs FunLex.fs
fsyacc --module FunPar FunPar.fsy
fslex --unicode FunLex.fsl
dotnet fsi -r ../../fsharp/FsLexYacc.Runtime.dll Fun/Absyn.fs Fun/FunPar.fs Fun/FunLex.fs Fun/Parse.fs Fun/HigherFun.fs Fun/ParseAndRunHigher.fs