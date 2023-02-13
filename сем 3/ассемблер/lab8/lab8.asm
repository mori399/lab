.model tiny 
.code
begin: 
    jmp start
    path        db  100 dup(0)
    param       db  0,0Dh
    EPB         dw  0
    par_off     dw  0
    par_seg     dw  0
                dw  0
                dw  0
                dw  0
                dw  0
 
start:  
    mov     ax,@code      
    mov     ds,ax
 
    mov di,82h
    mov bx,0
    lp:
    mov dl,es:[di]
    cmp dl,0dh
    je breaks
    mov ds:[offset path+bx],dl
    inc di
    inc bx
    jmp lp
    breaks:
    
    mov     bx,600h       
    mov     ah,4Ah
    int     21h
   
    mov     bx,offset param
    mov     par_off,bx       
    mov     par_seg,ds
    mov     ax,ds
    mov     es,ax
    
 
    mov     ah,4Bh          
    mov     al,0            
    mov     bx,offset EPB
    mov     dx,offset path
    
    mov cx,25
    call_:
    int     21h
    loop call_
    
    mov     ax,4C00h    
    int     21h
    
end start
