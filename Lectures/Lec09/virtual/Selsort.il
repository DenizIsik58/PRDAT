

  .method public hidebysig static void  SelectionSort(int32[] arr) cil managed
  {
    // Code size       57 (0x39)
    .maxstack  4        // 4 is the maximum number of items on the stack at any one time
    .locals init (int32 V_0, l
             int32 V_1,
             int32 V_2,
             int32 V_3)
    IL_0000:  ldc.i4.0  
    IL_0001:  stloc.0   
    IL_0002:  br.s       IL_0032 

    IL_0004:  ldloc.0 
    IL_0005:  stloc.1     
    IL_0006:  ldloc.0 
    IL_0007:  ldc.i4.1
    IL_0008:  add     // add the two values on the stack
    IL_0009:  stloc.3  // store the result into local variable 3
    IL_000a:  br.s       IL_001a // branch to IL_001a

    IL_000c:  ldarg.0  // load arr into stack
    IL_000d:  ldloc.3 // load V_3 into stack
    IL_000e:  ldelem.i4 // load the value at index V_3 into stack
    IL_000f:  ldarg.0 // load arr into stack
    IL_0010:  ldloc.1 // load V_1 into stack
    IL_0011:  ldelem.i4    // load the value at index V_1 into stack
    IL_0012:  bge.s      IL_0016 // branch to IL_0016 if the value on the stack is greater than or equal to 0

    IL_0014:  ldloc.3  // load V_3 into stack
    IL_0015:  stloc.1 // store V_3 into V_1
    IL_0016:  ldloc.3 // load V_3 into stack
    IL_0017:  ldc.i4.1 // load 1 into stack
    IL_0018:  add    // add the two values on the stack
    IL_0019:  stloc.3 // store the result into V_3
    IL_001a:  ldloc.3 // load V_3 into stack
    IL_001b:  ldarg.0 // load arr into stack
    IL_001c:  ldlen // load the length of arr into stack
    IL_001d:  conv.i4 // convert the value on the stack to int32
    IL_001e:  blt.s      IL_000c // branch to IL_000c if the value on the stack is less than 0

    IL_0020:  ldarg.0 // load arr into stack
    IL_0021:  ldloc.0 // load V_0 into stack
    IL_0022:  ldelem.i4 // load the value at index V_0 into stack
    IL_0023:  stloc.2 // store the value on the stack into V_2
    IL_0024:  ldarg.0 // load arr into stack
    IL_0025:  ldloc.0 // load V_0 into stack
    IL_0026:  ldarg.0 // load arr into stack
    IL_0027:  ldloc.1 // load V_1 into stack
    IL_0028:  ldelem.i4 // load the value at index V_1 into stack
    IL_0029:  stelem.i4 // store the value on the stack into the array at index V_0
    IL_002a:  ldarg.0 // load arr into stack
    IL_002b:  ldloc.1 // load V_1 into stack
    IL_002c:  ldloc.2 // load V_2 into stack
    IL_002d:  stelem.i4 // store the value on the stack into the array at index V_1
    IL_002e:  ldloc.0 // load V_0 into stack
    IL_002f:  ldc.i4.1 // load 1 into stack
    IL_0030:  add // add the two values on the stack
    IL_0031:  stloc.0 // store the result into V_0
    IL_0032:  ldloc.0 // load V_0 into stack
    IL_0033:  ldarg.0 // load arr into stack
    IL_0034:  ldlen // load the length of arr into stack
    IL_0035:  conv.i4 // convert the value on the stack to int32
    IL_0036:  blt.s      IL_0004 // branch to IL_0004 if the value on the stack is less than 0

    IL_0038:  ret // return from the method
  } // end of method Selsort::SelectionSort

