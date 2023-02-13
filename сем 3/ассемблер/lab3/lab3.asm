.model small
.data
string db 250,?, 256 dup ('$')
.code
start:
mov ax,@data
mov ds,ax
mov ax,0b800h
mov es,ax

mov ax,3
int 10h
mov ah,10
lea dx,string
int 21h


lea di,string+1
mov si,320
xor cx,cx
mov cl,byte ptr [di]
add di,cx
inc cx
mov dx,cx

mov al,' '
deg: push ds
pop es
std
repnz scasb
push di
xchg dx,cx
sub cx,dx
add di,2
dec cx
mov ax,0b800h
mov es,ax
cld
mov ah,7h
xchg si,di
begs: lodsb
stosw
loop begs
mov al,' '
stosw
mov si,di
pop di
mov cx,dx
or cx,cx
jnz deg


mov ah,10h
int 16h
mov ah,4ch
int 21h
end start
