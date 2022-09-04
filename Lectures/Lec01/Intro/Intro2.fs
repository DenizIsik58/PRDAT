(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

open System

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr;;



let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;

let eMax = Prim("max", Var "a", Var "c");;

let eMin = Prim("min", Var "a", Var "c");;

let eEquals = Prim("==", Var "a", Var "b");;

let eEquals2 = Prim("==", Var "b", Var "b");;

let eIf = If (Prim("==", Var "a", Var "b"), Var "a", Var "b");; 


(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x
    | If (e1, e2, e3) ->
      let i1 = eval e1 env
      let i2 = eval e2 env
      let i3 = eval e3 env
      if i1 = 1 then i2 else i3
    | Prim(ope, e1, e2) ->
      let i1 = eval e1 env
      let i2 = eval e2 env
      match ope with
      |"+" -> i1 + i2
      |"*" -> i1 * i2
      |"-" -> i1 - i2
      |"max" -> if i1 > i2 then i1 else i2
      |"min" -> if i1 < i2 then i1 else i2
      |"=="  -> if i1 = i2 then 1 else 0
      | _    -> failwith "unknown primitive"


type aexpr = 
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr

(*

v - (w + z) is represented as 
Sub(Var "v", Add(Var "w", Var "z"))

2 ∗ (v − (w + z)) is represented as 
Mult(CstI 2,(Sub(Var "v"(Add(Var "w", Var "z")))))

x + y + z + v is represented as 
Add(Var "x", Add(Var "y", Add(Var "z", Var "v")))
*)

let a1 = Sub(Var "v", Add(Var "w", Var "z"))
let a2 = Mul(CstI 2,(Sub(Var "v", Add(Var "w", Var "z"))))
let a3 = Add(Var "x", Add(Var "y", Add(Var "z", Var "v")))

let rec fmt aexp : string =
  match aexp with
  | CstI x -> sprintf "%d" x
  | Var x -> sprintf "%s" x
  | Add (e1, e2) -> sprintf "(%s + %s)" (fmt e1) (fmt e2)
  | Sub (e1, e2) -> sprintf "(%s - %s)" (fmt e1) (fmt e2)
  | Mul (e1,e2) -> sprintf "(%s * %s)" (fmt e1) (fmt e2)

let rec simplify aexpr : aexpr  =
  match aexpr with
  | Add (ae1, ae2) when simplify ae1 = CstI (0) -> simplify ae2
  | Add (ae1, ae2) when simplify ae2 = CstI (0) -> simplify ae1
  | Sub (ae1, ae2) when simplify ae2 = CstI (0) -> simplify ae1
  | Mul (ae1, ae2) when simplify ae1 = CstI (1) -> simplify ae2
  | Mul (ae1, ae2) when simplify ae2 = CstI (1) -> simplify ae1
  | Mul (ae1, ae2) when simplify ae1 = CstI (0) -> CstI (0)
  | Mul (ae1, ae2) when simplify ae2 = CstI (0) -> CstI (0)
  | Sub (ae1, ae2) when simplify ae1 = simplify ae2 -> CstI (0)
  | _ -> aexpr

let simplifyAdd1 = Add(CstI (0), CstI (5))
let simplifyAdd2 = Add (CstI (5), CstI (0))

let simplifySub1 = Sub(CstI(10),CstI(0))

let simplifyMul1 = Mul(CstI(1),CstI(10))
let simplifyMul2 = Mul(CstI (100), CstI (1))
let simplifyMul3 = Mul (CstI (0), Add(CstI (0), CstI (5)))
let simplifyMul4 = Mul (CstI (123123), Sub (CstI (15), CstI (15)))
let simplifySub2 = Sub(CstI(10), CstI(10))


let performDiff aexpr str : aexpr =
  match axepr with
    |CstI _ -> CstI 0
    |Var x when x = str -> CstI 1
    |Var _ -> CstI 0
    |Add(ae1, ae2) -> Add((performDiff ae1 str), (performDiff ae2 str))
    |Sub(ae1, ae2) -> Sub((performDiff ae1 str), (performDiff ae2 str))
    |Mul(ae1, ae2) -> Add(Mul(performDiff ae1 str, ae2), Mul(ae1, performDiff ae2 str))


let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;

(*
  Our own functions for min, max, equals and If
*)
let evalmax = eval eMax env;;
let evalmin = eval eMin env;;
let evalEqualFalse = eval eEquals env;;
let evalEqualTrue = eval eEquals2 env;;

let evalIf = eval eIf env;;