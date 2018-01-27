;; brainfuck to c compiler

#|
>	Move the pointer to the right
<	Move the pointer to the left
+	Increment the memory cell under the pointer
-	Decrement the memory cell under the pointer
.	Output the character signified by the cell at the pointer
,	Input a character and store it in the cell at the pointer
[	Jump past the matching ] if the cell under the pointer is 0
]	Jump back to the matching [ if the cell under the pointer is nonzero
|#

(defparameter *LOOK* nil)

(defun getchar()
  (setf *LOOK* (read-char *standard-input* nil)))

(defun report-error(s)
  (format t "~%Error: ~a.~%" s))

(defun abort-program(s)
  (report-error s)
  (abort))

(defun match(c)
  (if (char-equal c *LOOK*)
      (getchar)))

(defun emit (s)
  (format t "~a~a" #\tab s))

(defun emitln (s)
  (emit s)
  (terpri) ;; new line
  )

(defun bf->c ()
  (when (characterp *LOOK*)
    (cond ((char-equal *LOOK* #\> )
           (emitln "++ptr;"))
          ((char-equal *LOOK* #\< )
           (emitln "--ptr;"))
          ((char-equal *LOOK* #\+ )
           (emitln "++*ptr;"))
          ((char-equal *LOOK* #\- )
           (emitln "--*ptr;"))
          ((char-equal *LOOK* #\. )
           (emitln "putchar(*ptr);"))
          ((char-equal *LOOK* #\, )
           (emitln "*ptr=getchar();"))
          ((char-equal *LOOK* #\[ )
           (emitln "while (*ptr) {"))
          ((char-equal *LOOK* #\] )
           (emitln "}")))
    (getchar)))

(defun init()
  (getchar)
  )

(defun main()
  (emitln "#include <stdio.h>")
  (emitln "char array[1000000] = {0};")
  (emitln "char *ptr=array;")
  (emitln "int main(int argv, char** argc) {")
  (init)
  (loop while (characterp *LOOK*)
        do (bf->c))
  (emitln "return 0;")
  (emitln "}"))
