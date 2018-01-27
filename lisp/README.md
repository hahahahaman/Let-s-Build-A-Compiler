## Lisp code

### bf-to-c.lisp

#### How to use:

~~~

$ cat hello-world.b | sbcl --noinform --no-userinit --no-sysinit --load bf-to-c.lisp --eval "(progn (main) (sb-ext:quit))" > hello-world.c

$ gcc -Wall hello-world.b - o hello-world.bin
~~~

