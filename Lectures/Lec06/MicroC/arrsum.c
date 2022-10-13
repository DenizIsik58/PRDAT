//7.2 1 arrsum

void arrsum(int n, int arr[], int* sump) {
    n = n - 1;
    while (n >= 0) {
        *sump = *sump + arr[n];
        n = n - 1;
    }
}

void main(int n) {
    int arr[4];

    arr[0] = 7;
    arr[1] = 13;
    arr[2] = 9;
    arr[3] = 8; 

    int res;
    res = 0;
    arrsum(4, arr, &res);
    print res;
    println;
}

