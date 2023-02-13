
    .model tiny
    .code
    org 100h
start:  jmp beg

plot:   push cx
    push dx
    push di
    push es
    cmp cx,320
    jnc pl1
    cmp dx,200
    jnc pl1
    push ax
    mov ax,320 
    mul dx
    add ax,cx
    mov di,ax
    mov ax,0A000h
    mov es,ax
    pop ax
    mov es:[di],al 
pl1:    pop es
    pop di
    pop dx
    pop cx
    ret

 
linetosub:cmp bx,0
    jz lt1
lt0:    call plot 
    cmp ah,0  
    jz goN
    cmp ah,1 
    jz goNE
    cmp ah,2 
    jz goE
    cmp ah,3
    jz goSE
    cmp ah,4
        jz goS
    cmp ah,5
    jz goSW
    cmp ah,6
    jz goW
    cmp ah,7
    jz goNW
movcont:dec bx
    jnz lt0
lt1:    ret
goN:    dec dx 
    jmp movcont
goNE:   inc cx
    dec dx
    jmp movcont
goE:    inc cx
    jmp movcont
goSE:   inc cx
    inc dx
    jmp movcont
goS:    inc dx
    jmp movcont
goSW:   dec cx
    inc dx
    jmp movcont
goW:    dec cx
    jmp movcont
goNW:   dec cx
    dec dx
    jmp movcont
 

lineto  macro direction,size,color
    mov ah,direction
    mov al,color
    mov bx,size
    call linetosub
    endm
 
beg:    push cs
    pop  ds
    mov ax,13h 
    int 10h
    mov  cx,160 
    mov dx,100  
    lineto 0,50,15
    lineto 2,50,15
    lineto 4,50,15
    lineto 6,50,15
    mov  cx,160 
    mov dx,50
    lineto 1,25,15
    lineto 0,5,15
    lineto 4,5,15
    lineto 3,25,15
    mov  cx,190 
    mov dx,100
    mov  cx,170 
    mov dx,70
    mov cx,158 
    mov dx,100
    mov bx,6
z1: push bx
    pop  bx
    dec  bx
    jnz z1
 
    mov ah,0 
    int 16h
 
    mov ax,3 
    int 10h
    mov ax,4C00h 
    int 21h
    end start