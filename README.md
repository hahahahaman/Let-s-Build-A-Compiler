## Let's build a Compiler 

Planning to go through the `Let's Build a Compiler series` by Jack
Crenshaw, using x86_64 GForth compiling to LLVM Intermediate
Representation (IR) (also known as byte code).

### Why GForth?

Never used a stack based language before. GForth is the free GNU
implementation.

### Why LLVM IR?

It is the closest thing to a cross-platform assembly language that I
know of. I tried NASM, but it is not cross-platform. Maybe compiling
to C is also a reasonable option.

### Directories:

`./original/` contains all the original tutorial .txt files.

`./forth/` contains the Forth implementation.

`./c/` will possibly contain a C implementation of the tutorials.

`./lisp/` contains code for brainfuck compilers to C and LLVM IR.


