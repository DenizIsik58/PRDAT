//7.2 1 arrsum

void arrsum(int n, int arr[], int* sump) {
    int i;
    for(i = n-1; i >= 0; --i) {
        *sump = *sump + arr[i];
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

