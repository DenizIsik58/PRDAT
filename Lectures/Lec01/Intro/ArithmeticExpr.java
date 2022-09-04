import java.util.Map;
import java.util.HashMap;

abstract class ArithmeticExpr {
    abstract public ArithmeticExpr simplify();
    abstract public ArithmeticExpr performDiff(String str);
    abstract public int eval(Map<String, Integer> env);
    abstract public String toString();
}

abstract class Binop extends ArithmeticExpr{
    protected ArithmeticExpr ae1;
    protected ArithmeticExpr ae2;
}


class CstI extends ArithmeticExpr {
    protected int i;

    public CstI(int j) {
        this.i = j;
    }

    public String fmt() {
        return String.format("%d", i);
    }

    public ArithmeticExpr simplify() {
        return this;
    }

    @Override
    public ArithmeticExpr performDiff(String str) {
        return new CstI(0);
    }

    @Override
    public String toString(){
        return String.valueOf(i);
    }

    @Override
    public int eval(Map<String, Integer> env) {
        return i;
    }

}

class Var extends ArithmeticExpr {
    protected final String name;

    public Var(String name) { 
    this.name = name; 
    }

    @Override
    public ArithmeticExpr simplify() {
        return this;
    }

    @Override
    public ArithmeticExpr performDiff(String str) {
        return this.name == str ? new CstI(1) : new CstI(0);
    }

    @Override
    public String toString() {
        return name;
    }

    @Override
    public int eval(Map<String, Integer> env) {
        return env.get(name);
    }
}

class Add extends Binop {
    public Add(ArithmeticExpr ae1, ArithmeticExpr ae2){
        this.ae1 = ae1;
        this.ae2 = ae2;
    }

    @Override
    public ArithmeticExpr simplify() {
        if (ae1 instanceof CstI && ((CstI) ae1).i == 0) return ae2;
        if (ae2 instanceof CstI && ((CstI) ae2).i == 0) return ae1;
        return this;
    }

    @Override
    public ArithmeticExpr performDiff(String str) {
        
        return new Add(ae1.performDiff(str), ae2.performDiff(str));
    }

    @Override
    public String toString() {
        return String.format("(%s + %s)", ae1.toString(), ae2.toString());
    }

    @Override
    public int eval(Map<String, Integer> env) {
        return ae1.eval(env) + ae2.eval(env);
    }
}

class Sub extends Binop {
    
    public Sub (ArithmeticExpr ae1, ArithmeticExpr ae2){
        this.ae1 = ae1;
        this.ae2 = ae2;
    }

    @Override
    public ArithmeticExpr simplify() {
        if ((ae1 instanceof CstI) && (ae2 instanceof CstI) && ((CstI) ae1).i == ((CstI) ae2).i) return new CstI(0);
        else if ((ae2 instanceof CstI) && ((CstI) ae2).i == 0) return ae1;
        return this;
    }

    @Override
    public ArithmeticExpr performDiff(String str) {
        return new Add(ae1.performDiff(str), ae2.performDiff(str));
    }

    @Override
    public String toString() {
        return String.format("(%s - %s)", ae1.toString(), ae2.toString());
    }

    @Override
    public int eval(Map<String, Integer> env) {
        return ae1.eval(env) - ae2.eval(env);
    }
}

class Mul extends Binop {

    public Mul(ArithmeticExpr ae1, ArithmeticExpr ae2) {
        this.ae1 = ae1;
        this.ae2 = ae2;
    }

    @Override
    public ArithmeticExpr simplify() {
        if (ae1 instanceof CstI && ((CstI) ae1).i == 1) {
            return ae2;
        } else if (ae1 instanceof CstI && ((CstI) ae2).i == 1) {
            return ae1;
        } else if (ae1 instanceof CstI && ((CstI) ae1).i == 0 || ((CstI) ae2).i == 0) {
            return new CstI(0);
        }
        
        return this;
    }

    @Override
    public ArithmeticExpr performDiff(String str) {
        return new Add(new Mul(ae1.performDiff(str), ae2), ae2.performDiff(str));
    }
   
    @Override
    public String toString() {
        return String.format("(%s * %s)", ae1.toString(), ae2.toString());
    }

    @Override
    public int eval(Map<String, Integer> env) {
        return ae1.eval(env) * ae2.eval(env);
    }
    
}


class Main {
    static CstI csti = new CstI(15);
    static CstI cstiZero = new CstI (0);
    static CstI cstiOne = new CstI(1);
    static CstI cstiTen = new CstI(10);
    static CstI csti3 = new CstI(4);
    static Var var1 = new Var("a");
    static Var var2 = new Var("b");
    static Var var3 = new Var("c");
    
    static ArithmeticExpr add1 = new Add(cstiOne, new CstI(2));
    static ArithmeticExpr add2 = new Add(cstiZero, cstiOne);
    static ArithmeticExpr add3 = new Add(cstiOne, cstiZero);
    static ArithmeticExpr mul1 = new Mul(cstiOne, cstiTen);
    static ArithmeticExpr mul2 = new Mul(cstiTen, cstiOne);
    static ArithmeticExpr mul3 = new Mul(cstiTen, cstiZero);
    static ArithmeticExpr mul4 = new Mul(cstiZero, cstiTen);
    static ArithmeticExpr mul5 = new Mul(new CstI(3), new CstI(4));
    
    
    static ArithmeticExpr sub1 = new Sub(csti, cstiZero);
    static ArithmeticExpr sub2 = new Sub(csti, csti);
    static ArithmeticExpr sub3 = new Sub(csti, csti3);

    static Map<String, Integer> env = new HashMap<String,Integer>() {{
        put("a", 1);
        put("b", 2);
        put("c", 3);
    }};

    
    public static void main(String[] args) {
        simplify();
        eval();
    }
    
    
    public static void simplify(){
        System.out.println("SIMPLIFY");
        System.out.println();
        
        //CstI
        System.out.println("CstI");
        System.out.println(String.format("csti: %s actual %s", "15", csti.simplify()));

        //Var
        System.out.println("Var");
        System.out.println(String.format("var1 = %s, actual = %s", "a", var1.simplify()));
        System.out.println(String.format("var2 = %s, actual = %s", "b", var2.simplify()));
        System.out.println(String.format("var3 = %s, actual = %s", "c", var3.simplify()));
        
        //Add
        System.out.println("Add");
        System.out.println(String.format("add1 = %s, actual = %s", "(1 + 2)", add1.simplify()));
        System.out.println(String.format("add2 = %s, actual = %s", "1", add2.simplify()));
        System.out.println(String.format("add3 = %s, actual = %s", "1", add2.simplify()));
        
        //Sub
        System.out.println("Sub");
        System.out.println(String.format("sub1 = %s, actual = %s", "15", sub1.simplify()));
        System.out.println(String.format("sub2 = %s, actual = %s", "0", sub2.simplify()));
        System.out.println(String.format("sub3 = %s, actual = %s", "(15 - 4)", sub3.simplify()));

        //Mul
        System.out.println("Mul");
        System.out.println(String.format("mul1 = %s, actual = %s", "10", mul1.simplify()));
        System.out.println(String.format("mul2 = %s, actual = %s", "10", mul2.simplify()));
        System.out.println(String.format("mul3 = %s, actual = %s", "0", mul3.simplify()));
        System.out.println(String.format("mul4 = %s, actual = %s", "0", mul4.simplify()));
        System.out.println(String.format("mul5 = %s, actual = %s", "(3 * 4)", mul5.simplify()));

        System.out.println();
    }
    
    public static void eval(){
        System.out.println("EVAL");
        System.out.println();
        
        //CstI
        System.out.println("CstI");
        System.out.println(String.format("csti: %d actual %d", 15, csti.eval(env)));

        //Var
        System.out.println("Var");
        System.out.println(String.format("var1 = %d, actual = %d", 1, var1.eval(env)));
        System.out.println(String.format("var2 = %d, actual = %d", 2, var2.eval(env)));
        System.out.println(String.format("var3 = %d, actual = %d", 3, var3.eval(env)));
        
        //Add
        System.out.println("Add");
        System.out.println(String.format("add1 = %d, actual = %d", 3, add1.eval(env)));
        System.out.println(String.format("add2 = %d, actual = %d", 10, add2.eval(env)));
        System.out.println(String.format("add3 = %d, actual = %d", 1, add2.eval(env)));
        
        //Sub
        System.out.println("Sub");
        System.out.println(String.format("sub1 = %d, actual = %d", 15, sub1.eval(env)));
        System.out.println(String.format("sub2 = %d, actual = %d", 0, sub2.eval(env)));
        System.out.println(String.format("sub3 = %d, actual = %d", 11, sub3.eval(env)));

        //Mul
        System.out.println("Mul");
        System.out.println(String.format("mul1 = %d, actual = %d", 10, mul1.eval(env)));
        System.out.println(String.format("mul2 = %d, actual = %d", 10, mul2.eval(env)));
        System.out.println(String.format("mul3 = %d, actual = %d", 0, mul3.eval(env)));
        System.out.println(String.format("mul4 = %d, actual = %d", 0, mul4.eval(env)));
        System.out.println(String.format("mul4 = %d, actual = %d", 12, mul5.eval(env)));

        System.out.println();
    }
}
