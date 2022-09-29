(*5.1*)
let merge xs ys = 
  let rec aux xs ys acc =
    match xs, ys with
    | [],[] -> acc
    | [], ys -> ys @ acc
    | xs, [] -> xs @ acc
    | x :: xs', y :: ys' when y < x -> aux (x::xs') ys' (y :: acc)
    | x :: xs', y :: ys' -> aux xs' (y::ys') (x :: acc)
  aux xs ys [] |> List.rev


(* Higher-order functions and anonymous functions in F# *)
let rec map f xs = 
    match xs with 
      | []    -> []
      | x::xr -> f x :: map f xr


let mul2 x = 2.0 * x
map mul2 [4.0; 5.0; 89.0]

map (fun x -> 2.0 * x) [4.0; 5.0; 89.0]

map (fun x -> x > 10.0) [4.0; 5.0; 89.0]

(* Uniform iteration over a list *)
let rec sum xs = 
    match xs with 
      | []    -> 0
      | x::xr -> x + sum xr

let rec prod xs = 
    match xs with 
      | []    -> 1
      | x::xr -> x * prod xr

let rec foldr f xs e = 
    match xs with
      | []    -> e
      | x::xr -> f x (foldr f xr e)


(* Higher-order micro-ML/micro-F# *)
let twice g x = g(g x)

let add x = let f y = x+y in f
let addtwo = add 2 
let x = 77
addtwo 5


(* F# mutable references *)
let r = ref 177
!r
(r := !r+1; !r)
!r

let nextlab = ref -1
let newLabel () = (nextlab := 1 + !nextlab; 
                   "L" + string (!nextlab))
newLabel()


