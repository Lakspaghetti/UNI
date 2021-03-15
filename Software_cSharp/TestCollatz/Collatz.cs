namespace TestCollatz {
    public static class CollatzImpl {

        public static int Collatz(int n, int max_len, int max_size) {
            int len = 0;
            while (n > 1 && len <= max_len && n < max_size) {
                len++;
                if (n % 2 == 0) {
                    n = n / 2;
                } else {
                    n = 3 * n + 1;
                }
            }
            return len;
        }

        public static int CollatzRec(int n, int max_len, int max_size) {
            if (n < 1 || n > max_size || max_len <= 0) {
                return 0;
            } else if (n == 1) {
                return 1;
            } else {
                return 1 + (n % 2 == 0
                            ? CollatzRec(n / 2, max_len - 1, max_size)
                            : CollatzRec(3 * n + 1, max_len - 1, max_size));
            }
        }
    }
}