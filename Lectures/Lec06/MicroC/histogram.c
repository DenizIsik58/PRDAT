void histogram(int n, int ns[], int freq[]) {
    int i;
    for(i = 0; i < n; ++i) {
        int c;
        c = ns[i];
        freq[c] = freq[c] + 1;
    }
}

void main(int n) {
    int freq[3];
    freq[0] = 0;
    freq[1] = 0;
    freq[2] = 0;
    int ns[7];
    ns[0] = 1;
    ns[1] = 2;
    ns[2] = 1;
    ns[3] = 1;
    ns[4] = 1;
    ns[5] = 2;
    ns[6] = 0;
    histogram(7,ns,freq);
    int i;
    i = 0;
    while (i < 3){
        print freq[i];
        i = i + 1;
    }  
}