import java.util.Arrays;

public class Merge {
    public static void main(String[] args) {
        
       System.out.println(Arrays.toString(merge(new int[] {} , new int[] {})));

    }

    public static boolean isEmpty(int[] list) {
        return list.length == 0;
    }

    public static int[] merge (int[] a, int[] b) {
        
        if (isEmpty(a) && !isEmpty(b)) {
            return b;
        }

        if (!isEmpty(a) && isEmpty(b)) {
            return a;
        }

        int aPos = 0;
        int bPos = 0;
        int[] res = new int[a.length + b.length];

        for(int i = 0; i<res.length; i++){
            if (aPos >= a.length) {
                res[i] = b[bPos];
                bPos++;
            } else if (bPos >= b.length) {
                res[i] = a[aPos];
                aPos++;
            } else if (a[aPos] < b[bPos]) {
                res[i] = a[aPos];
                aPos++;
            } else {
                res[i] = b[bPos];
                bPos++;
            }
        }

    return res;
}


}
