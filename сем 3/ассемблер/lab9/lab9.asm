.model small
.stack 100h
.data
;???????, ??????????? ??? ??????? ?? Ctrl+C
constsize = 44
scr1 db 0c9h,constsize dup (0cdh),0bbh,'$'
scr2 db 0bah,constsize dup (20h),0bah,'$'
scr3 db 0cch,constsize dup (0cdh),0b9h,'$'
scr4 db 0c8h,constsize dup (0cdh),0bch,'$'
Mes_CtrlC db '     ?????? ????????? ?????? Ctrl + C     $'
   AnKey1 db '??? ?????? ?? ????????? - ??????? 1       $'
   AnKey2 db '??? ???????? ? ???????? ???-?? - ????? ??.$'  
   AnKey3 db '??? ?????:                                $'
 
.code
main proc
    mov ax,@data
    mov ds,ax   
install_int23h:
    push ds
    mov ax,@code 
    mov ds,ax
    mov ah,25h 
    mov al,23h 
    mov dx,offset Ctrl_CInt 
    int 21h
    pop ds
    xor cx,cx
L1:     
    mov ah,1
    int 21h
    cmp al,31h
    je endprog
    cmp al,1Bh 
    jnz L1 
endprog:
    mov ax,4C00h 
    int 21h
main endp
;?????????? ??????? Ctrl+C
;????????? ???????
Ctrl_CInt proc
    push ax 
    push dx
    push bx
    mov ax,0501h
    int 10h
    mov bh,1
    mov ah,2
    mov dl,7
    int 21h
    mov dx,0411h
    mov si,offset scr1
    call writechar 
    mov dx,0511h
    mov si,offset scr2
    call writechar 
    mov dx,0513h
    mov si,offset Mes_CtrlC
    call writechar
    mov dx,0611h
    mov si,offset scr3
    call writechar  
    mov dx,0711h
    mov si,offset scr2
    call writechar
    mov dx,0713h
    mov si,offset AnKey1 
    call writechar
    mov dx,0811h
    mov si,offset scr2
    call writechar
    mov dx,0813h
    mov si,offset AnKey2 
    call writechar  
    mov dx,0911h
    mov si,offset scr2
    call writechar
    mov dx,0913h
    mov si,offset AnKey3 
    call writechar  
    mov dx,0A11h
    mov si,offset scr4
    call writechar  
    mov ah,02h  
    mov bh,1
    mov dx,091Fh
    int 10h
    mov ah,01h
    int 21h
    xor cx,cx
    cmp al,31h
    je exctrlc
    mov cx,1h   
exctrlc:
    mov ax,0500h
    int 10h 
    pop bx
    pop dx
    pop ax
    iret
Ctrl_CInt endp
;????? ?????? ?? 1-? ????? ???????? (??? Ctrl+C)
;DH/DL - ??????\??????? ??????
;SI - ???????? ??????
writechar proc
    mov ah,02h  
    mov bh,1
    int 10h     
    mov bl,0Eh          
c1: 
    mov al,[SI]
    mov cx,1        
    mov ah,09h
    int 10h         
    mov ah,02h  
    inc dl              
    mov bh,1        
    int 10h
    inc SI      
    mov al,[SI]
    cmp al,'$'  
    je ec1  
    jmp c1
ec1:
    ret
writechar endp
end main