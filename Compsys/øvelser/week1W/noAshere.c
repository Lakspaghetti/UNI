#include <stdio.h>
#include <assert.h>

int main(int argc, char* argv[]) {
    assert(argc == 2);

    FILE* file = fopen(argv[1], "r");

    if (file) {
        char c;
        c = fgetc(file);

        while (c != EOF) {
            if (c == 'a' || c == 'A') {
                printf("No A's or a's are allowed\n");
                fclose(file);
                return 0;
            } else {
                c = fgetc(file);
            }
        }

        printf("ok, no a's or A's were found\n");
        fclose(file);
        return 1;

    } else {
        printf("The file %s was not found\n", argv[1]);
        return 0;
    }
    return 0;
}