## Lisp code

### bf-to-c.lisp

#### How to use:

~~~

./bf-to-c.sh foo.b foo.c

~~~

### bf-to-llvmir.lisp

#### How to use:

~~~

./bf-to-llvmir.sh foo.b foo.ll

~~~

To convert a C/C++ file, `foo.c`, to a LLVM IR file, `foo.ll`:

~~~

clang -S -emit-llvm -O3 foo.c


~~~

Why -O3? It removes unnecessary instructions.
https://stackoverflow.com/questions/15548023/clang-optimization-levels



To compile LLVM IR, `foo.ll`, to assembly, `foo.s`:

~~~

llc foo.ll

~~~

To go from assembly, `foo.s` to executable:

~~~

as foo.s -o foo.o

ld foo.o -o foo.bin

~~~
