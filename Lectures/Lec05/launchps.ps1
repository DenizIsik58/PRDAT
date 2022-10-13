cd ..
cd ..
cd Lectures/Lec05/ 
rm -r FunPar.fs FunLex.fs
fsyacc --module FunPar FunPar.fsy
fslex --unicode FunLex.fsl
dotnet fsi -r ../../fsharp/FsLexYacc.Runtime.dll Absyn.fs FunPar.fs FunLex.fs Parse.fs TypeInference.fs ParseAndType.fs
