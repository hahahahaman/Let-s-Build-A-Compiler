#! /bin/bash

echo "Compiling brainfuck -> C."
echo "$1 -> $2"


cat "$1" | sbcl --noinform --no-userinit --no-sysinit --load \
                bf-to-c.lisp --eval "(progn (main) (sb-ext:quit))" > "$2"

echo "DONE."
