.486
model small
Data SEGMENT use16
ASSUME ds:Data
ValA dw 2 ;A
ValC dw 435 ; B
ValD dw 5 ; C
Sign db 0 
;3
Strk db 7 dup(0),0 
Data ENDS
Stk SEGMENT use16 STACK
ASSUME ss:Stk
db 256 dup(0)
Stk ENDS
Code SEGMENT use16
ASSUME cs:Code
start:
int 10h
;(2*C-D/4)/(A*A+1)

mov ax, seg ValA
mov ds, ax
mov ax, ValC
mov cx, 2
imul cx ;2*C

push ax 

xor dx, dx

mov ax, ValD
mov cx, 4
idiv cx ;D/4 

pop bx
sub bx, ax

push bx 

mov ax, ValA
mov bx, ValA
imul bx

mov cx, 1
add cx, ax

pop ax
idiv cx






or ax, ax 
jns next0 
neg ax
mov byte ptr Sign, 1

next0:
lea si, Strk 
add si, 6 
mov cx, 10 
next1:
xor dx, dx 
div cx 
add dl, 48 
mov ds:[si], dl 
or ax, ax 
jz next2 
dec si 
jmp next1 
next2:
mov ax, 0b800h 
mov es, ax 
xor di, di 
mov ah, 0Fh 
cmp byte ptr Sign, 1 
jnz next4 
mov al, ?-? 
stosw 
next4:
lodsb 
or al, al 
jz next3 
stosw 
jmp next4 
next3:
in al, 60h 
cmp al, 1 
jnz next3 
mov ax, 03
int 10h
mov ax, 4c00h 
int 21h 
Code ENDS
end start