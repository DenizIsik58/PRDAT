
void squares(int n, int arr[]) {
    int i;

    for(i = 0; i < n; i = ++i) {
        arr[i] = (i + 1) * (i + 1);
    }    
}

void arrsum(int n, int arr[], int* sump) {
    n = n - 1;
    while (n >= 0) {
        *sump = *sump + arr[n];
        n = n - 1;
    }
}

void main(int n) {
    int res;
    res = 0;
    int arr[20]; 
    squares(n,arr);
    arrsum(n, arr, &res);
    print res;
    
}
