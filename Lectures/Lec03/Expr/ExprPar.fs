// Implementation file for parser generated by fsyacc
module ExprPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "ExprPar.fsy"

  (* File Expr/ExprPar.fsy
     Parser specification for the simple expression language.
   *)

  open Absyn

# 14 "ExprPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | LPAR
  | RPAR
  | END
  | IN
  | LET
  | COLON
  | QMARK
  | PLUS
  | MINUS
  | TIMES
  | DIVIDE
  | EQ
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_END
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_COLON
    | TOKEN_QMARK
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIVIDE
    | TOKEN_EQ
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Expr

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | LPAR  -> 1 
  | RPAR  -> 2 
  | END  -> 3 
  | IN  -> 4 
  | LET  -> 5 
  | COLON  -> 6 
  | QMARK  -> 7 
  | PLUS  -> 8 
  | MINUS  -> 9 
  | TIMES  -> 10 
  | DIVIDE  -> 11 
  | EQ  -> 12 
  | NAME _ -> 13 
  | CSTINT _ -> 14 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_LPAR 
  | 2 -> TOKEN_RPAR 
  | 3 -> TOKEN_END 
  | 4 -> TOKEN_IN 
  | 5 -> TOKEN_LET 
  | 6 -> TOKEN_COLON 
  | 7 -> TOKEN_QMARK 
  | 8 -> TOKEN_PLUS 
  | 9 -> TOKEN_MINUS 
  | 10 -> TOKEN_TIMES 
  | 11 -> TOKEN_DIVIDE 
  | 12 -> TOKEN_EQ 
  | 13 -> TOKEN_NAME 
  | 14 -> TOKEN_CSTINT 
  | 17 -> TOKEN_end_of_input
  | 15 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 17 
let _fsyacc_tagOfErrorTerminal = 15

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | END  -> "END" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | COLON  -> "COLON" 
  | QMARK  -> "QMARK" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIVIDE  -> "DIVIDE" 
  | EQ  -> "EQ" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | COLON  -> (null : System.Object) 
  | QMARK  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIVIDE  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 9us; 65535us; 0us; 2us; 8us; 9us; 18us; 11us; 19us; 12us; 22us; 13us; 23us; 14us; 25us; 15us; 26us; 16us; 27us; 17us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 5us; 1us; 6us; 8us; 9us; 10us; 1us; 1us; 1us; 2us; 1us; 3us; 1us; 4us; 1us; 4us; 1us; 5us; 5us; 5us; 6us; 8us; 9us; 10us; 1us; 5us; 5us; 6us; 6us; 8us; 9us; 10us; 5us; 6us; 6us; 8us; 9us; 10us; 5us; 6us; 7us; 8us; 9us; 10us; 5us; 6us; 7us; 8us; 9us; 10us; 5us; 6us; 8us; 8us; 9us; 10us; 5us; 6us; 8us; 9us; 9us; 10us; 5us; 6us; 8us; 9us; 10us; 10us; 1us; 6us; 1us; 6us; 1us; 7us; 1us; 7us; 1us; 7us; 1us; 7us; 1us; 7us; 1us; 8us; 1us; 9us; 1us; 10us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 10us; 12us; 14us; 16us; 18us; 20us; 22us; 28us; 30us; 36us; 42us; 48us; 54us; 60us; 66us; 72us; 74us; 76us; 78us; 80us; 82us; 84us; 86us; 88us; 90us; |]
let _fsyacc_action_rows = 28
let _fsyacc_actionTableElements = [|5us; 32768us; 1us; 8us; 5us; 20us; 9us; 6us; 13us; 4us; 14us; 5us; 0us; 49152us; 5us; 32768us; 0us; 3us; 7us; 18us; 8us; 26us; 9us; 27us; 10us; 25us; 0us; 16385us; 0us; 16386us; 0us; 16387us; 1us; 32768us; 14us; 7us; 0us; 16388us; 5us; 32768us; 1us; 8us; 5us; 20us; 9us; 6us; 13us; 4us; 14us; 5us; 5us; 32768us; 2us; 10us; 7us; 18us; 8us; 26us; 9us; 27us; 10us; 25us; 0us; 16389us; 5us; 32768us; 6us; 19us; 7us; 18us; 8us; 26us; 9us; 27us; 10us; 25us; 4us; 16390us; 7us; 18us; 8us; 26us; 9us; 27us; 10us; 25us; 5us; 32768us; 4us; 23us; 7us; 18us; 8us; 26us; 9us; 27us; 10us; 25us; 5us; 32768us; 3us; 24us; 7us; 18us; 8us; 26us; 9us; 27us; 10us; 25us; 1us; 16392us; 7us; 18us; 2us; 16393us; 7us; 18us; 10us; 25us; 2us; 16394us; 7us; 18us; 10us; 25us; 5us; 32768us; 1us; 8us; 5us; 20us; 9us; 6us; 13us; 4us; 14us; 5us; 5us; 32768us; 1us; 8us; 5us; 20us; 9us; 6us; 13us; 4us; 14us; 5us; 1us; 32768us; 13us; 21us; 1us; 32768us; 12us; 22us; 5us; 32768us; 1us; 8us; 5us; 20us; 9us; 6us; 13us; 4us; 14us; 5us; 5us; 32768us; 1us; 8us; 5us; 20us; 9us; 6us; 13us; 4us; 14us; 5us; 0us; 16391us; 5us; 32768us; 1us; 8us; 5us; 20us; 9us; 6us; 13us; 4us; 14us; 5us; 5us; 32768us; 1us; 8us; 5us; 20us; 9us; 6us; 13us; 4us; 14us; 5us; 5us; 32768us; 1us; 8us; 5us; 20us; 9us; 6us; 13us; 4us; 14us; 5us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 6us; 7us; 13us; 14us; 15us; 16us; 18us; 19us; 25us; 31us; 32us; 38us; 43us; 49us; 55us; 57us; 60us; 63us; 69us; 75us; 77us; 79us; 85us; 91us; 92us; 98us; 104us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 1us; 2us; 3us; 5us; 7us; 3us; 3us; 3us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 16386us; 16387us; 65535us; 16388us; 65535us; 65535us; 16389us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16391us; 65535us; 65535us; 65535us; |]
let _fsyacc_reductions ()  =    [| 
# 165 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startMain));
# 174 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 28 "ExprPar.fsy"
                                                               _1                
                   )
# 28 "ExprPar.fsy"
                 : Absyn.expr));
# 185 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 32 "ExprPar.fsy"
                                                               Var _1            
                   )
# 32 "ExprPar.fsy"
                 : 'Expr));
# 196 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 33 "ExprPar.fsy"
                                                               CstI _1           
                   )
# 33 "ExprPar.fsy"
                 : 'Expr));
# 207 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "ExprPar.fsy"
                                                               CstI (- _2)       
                   )
# 34 "ExprPar.fsy"
                 : 'Expr));
# 218 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "ExprPar.fsy"
                                                               _2                
                   )
# 35 "ExprPar.fsy"
                 : 'Expr));
# 229 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 36 "ExprPar.fsy"
                                                               If(_1, _3, _5)    
                   )
# 36 "ExprPar.fsy"
                 : 'Expr));
# 242 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 37 "ExprPar.fsy"
                                                               Let(_2, _4, _6)   
                   )
# 37 "ExprPar.fsy"
                 : 'Expr));
# 255 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "ExprPar.fsy"
                                                               Prim("*", _1, _3) 
                   )
# 38 "ExprPar.fsy"
                 : 'Expr));
# 267 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "ExprPar.fsy"
                                                               Prim("+", _1, _3) 
                   )
# 39 "ExprPar.fsy"
                 : 'Expr));
# 279 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "ExprPar.fsy"
                                                               Prim("-", _1, _3) 
                   )
# 40 "ExprPar.fsy"
                 : 'Expr));
|]
# 292 "ExprPar.fs"
let tables () : FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 18;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
