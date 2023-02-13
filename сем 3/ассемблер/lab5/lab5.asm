.Model Small

draw_row Macro x, y, z, color
 Local L1

    MOV AH,  0CH
    MOV AL,  color
    MOV CX,  y
    MOV DX,  x
L1: INT 10h
    INC CX
    CMP CX, z
    JL L1
 EndM

 draw_column Macro x,y,z,color 
 Local L2

    MOV AH, 0CH
    MOV AL, color
    MOV CX, x
    MOV DX, y
L2: INT 10h
    INC DX
    CMP DX, z
    JL L2
    EndM

    display_string Macro x,row,column,length,color

    push ax
    push bx

    MOV AX, @DATA
    MOV ES, AX  
    
    MOV AH, 13H 
    MOV AL, 0H
    XOR BH,BH 
    mov bl,color
    
    MOV BP, OFFSET x 
    MOV CX, length 
    MOV DH, row 
    MOV DL, column 
    INT 10H
    
    pop bx
    pop ax
    
    EndM  
    
    
draw_block Macro start_row, end_row, start_column, end_column, color_block
   Local along_row
   

       
    MOV DX, start_row
  
    along_row:
    
    draw_row  DX, start_column, end_column,color_block
         INC DX
         CMP DX, end_row
         JLE along_row
       
    EndM

  
draw_full_block Macro pattern_name, color, compare  
    Local draw
    

    
    MOV BX,0
    
    draw:
    draw_block [pattern_name+BX],[pattern_name+BX+2],[pattern_name+BX+4],[pattern_name+BX+6],color
        ADD BX,8
        CMP BX,compare
        JLE draw
    
    EndM
        

 
update_block Macro pattern_name, blockToBeUpdated
    local while
    
    push ax
    push bx
    push cx
    mov cx,16
    mov bx,0
    
    while:
       mov ax,pattern_name[bx]
       mov blockToBeUpdated[bx],ax
       add bx,2
     
       loop while
         
    pop cx
    pop bx
    pop ax
    EndM
   
   

    

modify_row_elements Macro pattern_name, delta, number_of_blocks 
    local ghuro,exit
    
    push ax
    push bx
    PUSH CX
    PUSH DX
    
    
 
    
    mov cx,number_of_blocks
    mov bx,0
    
    ghuro:
        
        xor ax,ax
        xor dx,dx
        
        MOV ax,pattern_name[bx]
        add ax,delta
        MOV pattern_name[bx],ax
        
        add bx,2
        
        MOV dx,pattern_name[bx]
        add dx,delta
        MOV pattern_name[bx],dx
        
        add bx,6
        
        loop ghuro
  
    
    exit:
        pop dx
        pop cx
        pop bx
        pop ax

    EndM 
    

   
modify_column_elementsD Macro pattern_name, delta, compare
    local byebye,shorao
    
    
   push ax
   push bx
   PUSH CX
   PUSH DX
    
  
    
    mov bx,4
    
    shorao: 
        
      
 
   koop:     
        MOV cx,pattern_name[bx]
        add cx,delta
        cmp cx,380
        jge byebye
        MOV pattern_name[bx],cx
        
        add bx,2
        MOV dx,pattern_name[bx]
        
        add dx,delta
        MOV pattern_name[bx],dx
        
        add bx,6
        xor cx,cx
        xor dx,dx
        
        cmp bx,compare
        jle shorao
        
        
  
    byebye:

        
        pop dx
        pop cx
        pop bx
        pop ax
        
    EndM    
   
    
modify_column_elementsA Macro pattern_name, delta, compare
    local byebye,shorao
    
        push ax
        push bx
        PUSH CX
        PUSH DX
    
  
    
    mov bx,4
    
    shorao:
        
        
        MOV cx,pattern_name[bx]
        sub cx,delta
        cmp cx,220
        jle byebye
        MOV pattern_name[bx],cx
        
        add bx,2
        MOV dx,pattern_name[bx]
        sub dx,delta
        MOV pattern_name[bx],dx
        
        
        add bx,6
        xor cx,cx
        xor dx,dx
        
        cmp bx,compare
        jle shorao
        

    byebye:
        
    
        
            pop dx
            pop cx
            pop bx
            pop ax
        

    EndM  


 
time_delay Macro pattern_name
    Local tt,tt1,tt2,tt3,tt4,tt5,tt6,tt7,tt8,tt9,tt10,tt11,sesh,show
 
    push bx
    push cx
    push dx
    
    tt:
        CMP timer_flag, 1
        JNE tt
        MOV timer_flag, 0
       
        
        
        
        CALL move_block
      
        
        
        mov bx,pattern_name[16]
        cmp bX,158 
        jg sesh
        
        
        
    tt2:
        CMP timer_flag, 1
        JNE tt2
        MOV timer_flag, 0
    tt3:
        CMP timer_flag,1
        JNE tt3
        MOV timer_flag,0
    tt4:
        CMP timer_flag,1
        JNE tt4
        MOV timer_flag,0
    tt5:
        CMP timer_flag,1
        JNE tt5
        MOV timer_flag,0
    tt6:
        CMP timer_flag,1
        JNE tt6
        MOV timer_flag,0
    tt7:
        CMP timer_flag,1
        JNE tt7
        MOV timer_flag,0
    tt8:
        CMP timer_flag,1
        JNE tt8
        MOV timer_flag,0
    tt9:
        CMP timer_flag,1
        JNE tt9
        MOV timer_flag,0
    tt10:
        CMP timer_flag,1
        JNE tt10
        MOV timer_flag,0
    tt11:
        CMP timer_flag,1
        JNE tt11
        MOV timer_flag,0

      JMP tt
    
      
    sesh:
    
     
    
    pop dx
    pop cx
    pop bx
    EndM 
   
  

.Stack 100h


.Data
new_timer_vec   dw  ?,?
old_timer_vec   dw  ?,?
a1              dw ?
a2              dw ?
b1              dw ?
b2              dw ?
score           dw ?
flagg           db 0
color           db 4
seshs           db 0
next_color      db 9
line            dw 0
timer_flag      db  0
vel_x           dw  1
vel_y           dw  1
boxer_a         dw  ?   
boxer_b         dw  ?  


msg_next       db "Next$",0
msg_left       db "A - Left$"
msg_right      db "D - Right$"
msg_rotate     db "S - Jump Fast$"
msg_quit       db "Q - Quit$"
msg_lines      db "Lines$"
msg_score      db "Score$"
msg_game_over  db "Game Over!$"
msg_tetris     db "TETRIS$"
game_score     db "0000$"



screen_width       dw 320
column_limit       dw 0
row_limit          dw 0
block_width        dw 10
block_height       dw 5
block_boundary     dw 153
block_boshche      dw 0
box_medium         dw 100
current_row        dw 0
current_block      dw 0
next_block         dw 0


horizontal             dw 51,56,290,300
                       dw 51,56,300,310
                       dw 51,56,310,320
                       dw 0,0,0,0
                       

next_horizontal        dw 71,76,430,440
                       dw 71,76,440,450
                       dw 71,76,450,460
                       dw 0,0,0,0
                       
              
vertical               dw 51,56,285,295
                       dw 56,61,285,295 
                       dw 61,66,285,295
                       
                       
                       
T_shape                dw 51,56,290,300
                       dw 51,56,300,310
                       dw 51,56,310,320
                       dw 56,62,310,320
                       
       
L_shape                dw 51,56,290,300
                       dw 51,56,300,310
                       dw 51,56,310,320
                       dw 45,50,290,300
                       
                       
next_L_shape           dw 71,76,430,440
                       dw 71,76,440,450
                       dw 71,76,450,460
                       dw 65,70,430,440


                       
Ulta_L                 dw 51,56,290,300
                       dw 51,56,300,310
                       dw 51,56,310,320
                       dw 57,64,310,320
                       

Ulta_T                 dw 51,56,290,300
                       dw 51,56,300,310
                       dw 51,56,310,320
                       dw 45,50,310,320
                       
                       
right_L                dw 51,56,290,300
                       dw 51,56,300,310
                       dw 51,56,310,320
                       dw 45,50,310,320 
                       
                       
next_right_L           dw 71,76,430,440
                       dw 71,76,440,450
                       dw 71,76,450,460
                       dw 65,70,450,460
                       
                          
currentBlock           dw 0,0,0,0
                       dw 0,0,0,0
                       dw 0,0,0,0
                       dw 0,0,0,0

next_piece             dw 0,0,0,0
                       dw 0,0,0,0
                       dw 0,0,0,0
                       dw 0,0,0,0
                       
offsetArray            dw 20,20,140,140
                       dw 20,20,140,140
                       dw 20,20,140,140 
                       dw 20,20,140,140 
                       
temp_nxt_piece         dw 0,0,0,0
                       dw 0,0,0,0
                       dw 0,0,0,0
                       dw 0,0,0,0
                       
               
choose_random_piece    dw 0,0,0,0
                       dw 0,0,0,0
                       dw 0,0,0,0
                       dw 0,0,0,0
                       
                       
zero_matrix            dw 0,0,0,0
                       dw 0,0,0,0
                       dw 0,0,0,0
                       dw 0,0,0,0
                        
                      



.CODE

MAIN PROC 


   MOV AX,@DATA
   MOV DS,AX 

   mov AH,0
   MOV AL,0eh
   int 10h
   

   mov ah,0bh
   mov bh,0
   mov bl,15
   int 10h
   

    call procedure_draw_screen
    
    draw_block 158,164,236,360,0fh
    
   
    MOV new_timer_vec, offset timer_tick
    MOV new_timer_vec+2, CS
    MOV AL, 1CH
    LEA DI, old_timer_vec
    LEA SI, new_timer_vec
    CALL setup_int
  
    
  
    mov score,0
    
 
notun_notun_block_banao:
        
      
        
        inc [current_block]
        cmp [current_block],3
        jle continue_kor
        
        mov [current_block],1
    
        continue_kor:
        
            call gen_block
      
            update_block choose_random_piece, currentBlock
            
            call gen_next_piece
            call show_next_piece
            
            time_delay currentBlock
             
            call hawahawaline 
            
           
            
            call score_dekhao
            call gameover
            cmp seshs,23
            je seshh
            add color,5
            add next_color,5
            cmp color,14
            jg Ooops
            
            cmp next_color,14
            jg Ooops_next
            
            jmp notun_notun_block_banao
Ooops:  
        mov color,4
        jmp notun_notun_block_banao
        
Ooops_next:  
        mov next_color,4
        jmp notun_notun_block_banao
seshh:
    
   mov ah,0
   mov al,13h
   int 10h
      

   mov ah,0bh
   mov bh,0
   mov bl,10
   int 10h


   display_string msg_game_over ,10,15,10,2 
    display_string msg_game_over ,10,15,10,2
     display_string msg_game_over ,10,15,10,2
      display_string msg_game_over ,10,15,10,2
      
    
   jmp seshh
        
   MAIN ENDP



procedure_draw_screen proc near
    
    draw_screen_border:
        
        
        draw_row 5,10,630,03h
       
        draw_column 10,5,195,03h
        
        draw_column 630,5,195,03h
      
        draw_row 195,10,630,03h
        
    
    draw_screen_play_area:
        
      
        draw_row 42,228,381,7
   
        draw_column 228,42,165,7
    
        draw_column 381,42,165,7
       
        draw_row 165,228,381,7
        
        
    draw_screen_next_piece:
      
        draw_row 50,400,487,01h
      
        draw_column 400,50,90,01h
      
        draw_column 487,50,90,01h
     
        draw_row 90,400,487,01h
        
    
    draw_screen_strings:
        
        
        display_string msg_left,10,10,8,9
       
        display_string msg_right,12,10,9,12
       
        display_string msg_rotate,14,10,13,8
    
        display_string msg_tetris,3,35,6,6
        
        display_string msg_next,12,54,4,8
        
        display_string msg_score,18,53,5,9
        
        display_string game_score,16,53,4,8
        
        ret
    
procedure_draw_screen endp



setup_int Proc


    MOV AH, 35h     
    INT 21h
    MOV [DI], BX    
    MOV [DI+2], ES  
        


    MOV DX, [SI]   
    PUSH DS         
    MOV DS, [SI+2]  
    MOV AH, 25h    
    INT 21h
    POP DS
    RET
setup_int EndP


timer_tick Proc
    PUSH DS
    PUSH AX
    
    MOV AX, Seg timer_flag
    MOV DS, AX
    MOV timer_flag, 1
    
     
exit:    
    POP AX
    POP DS
    
    IRET
timer_tick EndP




move_block Proc


    mov ah, 1 
    int 16h

    jz foo
    mov ah, 0   
    int 16h 
    cmp al,97 
    je keya
    cmp al,100 
    je fix2
    cmp al,115
    je dours
    foo: jmp boo
    
    keya:
    
      
       xor cx,cx
       xor dx,dx
       mov cx,currentBlock[20]
       sub cx,45
       mov dx,currentBlock[16]
fix1:   
       jmp fix3
fix2:
       jmp keyd
dours: jmp dour
fix3:
      
      
       mov ah,0dh
        
        
       int 10h
       cmp al,09h
       je boo
       cmp al,0eh
       je boo
       cmp al,04h
       je boo
       add dx,10
       int 10h
       cmp al,0eh
       je boo
       cmp al,09h
       je boo
       cmp al,04h
       je boo
      
    
       draw_full_block currentBlock,15 , 24
       modify_column_elementsA currentBlock,30,30
        
    boo:   jmp exittt
    
    dour:  
         jmp exitttt
    
    keyd: 
   
       xor cx,cx
       xor dx,dx
       mov cx,currentBlock[20]
       add cx,15
       mov dx,currentBlock[16]
       
       
       mov ah,0dh
        
        
       int 10h
       cmp al,09h
       je exittt
       cmp al,0eh
       je exittt
       cmp al,04h
       je exittt
       
       add dx,10
       int 10h
       cmp al,09h
       je exittt
       cmp al,0eh
       je exittt
       cmp al,04h
       je exittt
    

    draw_full_block currentBlock,15 , 30
    modify_column_elementsD currentBlock,30,30
        jmp exittt


    
exittt:    
    
      draw_full_block currentBlock,15, 24
      
 
      jmp test_timer
      
     
 exitttt:
    
 draw_full_block currentBlock,15, 24

       xor cx,cx
       xor dx,dx
       mov cx,currentBlock[4]
       inc cx
       
       mov dx,currentBlock[16]
       
        xor ax,ax
     
          mov ah,0dh
        
       cmp dx,140
       jg test_timer 
       add dx,24
       
       int 10h
       cmp al,09h
       je test_timer
       cmp al,0eh
       je test_timer
       cmp al,04h
       je test_timer
       add cx,20
       int 10h
       cmp al,09h
       je test_timer
       cmp al,0eh
       je test_timer
       cmp al,04h
       je test_timer
 

       modify_row_elements currentBlock,12, 4
    jmp test_timer
 
test_timer:
   
    xor ax,ax
    CMP timer_flag, 1
    JNE test_timer
    
    modify_row_elements currentBlock,6 ,16
    
    draw_full_block currentBlock,color,24

       xor cx,cx
       xor dx,dx
       mov cx,currentBlock[4]
       inc cx

       mov dx,currentBlock[16]
       add dx,10

       mov ah,0dh
        
        
       int 10h
       cmp al,09h
       je exits2
       cmp al,0eh
       je exits2
       cmp al,04h
       je exits2
       
       add cx,20
      
       int 10h
       cmp al,09h
       je exits2
       cmp al,0eh
       je exits2
       cmp al,04h
       je exits2   
 
    
    MOV timer_flag, 0

    exits:
    
        RET
        
    exits2:
    

    mov currentBlock[16],170
    
    RET   
            
move_block EndP


hawahawaline Proc

   xor ax,ax
   xor bx,bx
   xor cx,cx
   xor dx,dx
    
hambahamba:
    
     mov ah,0dh
    
     mov a1,164
     mov b1,56
     mov a2,230
     mov b2,240
     
    
    
     mov line,170

khuru:
      mov cx,235
      sub line,6
      mov dx,line
      mov a1,dx
dhuru:
    add cx,10
    cmp cx,380
    jg prehh1
    xor ax,ax
    mov ah,0dh    
    int 10h
    cmp al,09h
    je dhuru
    cmp al,0eh
    je dhuru
    cmp al,04h
    je dhuru
    jmp hh3
    
prehh1:
     add score,10
 hh1:
    
    mov a2,220
    sub a1,6
  hh2:
    
    cmp a1,55
    jl hh3
    
    add a2,10
    cmp a2,370
    jg hh1
    
    mov bx,a1
    add bx,6
    mov b1,bx
    
    mov bx,a2
    add bx,10
    mov b2,bx
    xor ax,ax
    xor bx,bx
    xor cx,cx
    xor dx,dx
    mov cx,a2
    inc cx
 
    mov dx,a1
    sub dx,4
    mov ah,0dh
    int 10h
    draw_block a1,b1,a2,b2,al  
    jmp hh2
    
hh3: 
    mov a2,220
    cmp line,60
    jl fillhoynai
    jmp khuru
    
fillhoynai:

    RET
hawahawaline Endp


score_dekhao proc
        
        push ax
        push bx
        push cx
        push dx
        
        
        mov cx,10d
        xor bx,bx
        mov bx,3
        mov ax,score
        
        bhag_kor:
            
            xor dx,dx
            div cx
            
     
            
            or dl,30h
            mov game_score[bx],dl
            dec bx
            
            
            or ax,ax
            jne bhag_kor
            
         
       

         display_string game_score,16,53,4,8
         
         
         pop dx
         pop cx
         pop bx
         pop ax
        
       
        ret


score_dekhao Endp


gen_block proc

    cmp [current_block],1
    je horizontal_ako
    
    cmp [current_block],2
    je L_shape_ako
     
    cmp [current_block],3
    je right_L_ako
    
    
    horizontal_ako:
            update_block horizontal, choose_random_piece
            mov [next_block],2
            ret
   
            
    L_shape_ako:
            update_block L_shape, choose_random_piece
            mov [next_block],3
            ret
               
    right_L_ako:
             update_block right_L, choose_random_piece
             mov [next_block],1
             ret
      
    
    ret 
    
gen_block endp


gen_next_piece proc
    
    cmp [next_block],1
    je horizontal_akao
    
    cmp [next_block],2
    je L_shape_akao
    
    cmp [next_block],3
    je right_L_akao
    
   
    horizontal_akao:
            update_block next_horizontal, next_piece
            ret
            
    L_shape_akao:
           update_block next_L_shape, next_piece
           ret
            
    right_L_akao:
             update_block next_right_L, next_piece
             ret

         
    ret 


gen_next_piece endp


show_next_piece proc 
   
       push bx
       push cx
       push dx
       
       draw_block 61,89,401,470,0Fh
       

           draw_full_block next_piece, [next_color], 24

      pop dx
      pop cx
      pop bx
      
      ret
      
show_next_piece endp


update_to_zero macro input
    local zero_banao

    push bx
    push cx
    
    mov bx,0
    mov cx,16
    
    zero_banao:
            mov input[bx],0
            add bx,2
            loop zero_banao
   

    EndM


gameover proc
    xor ax,ax
    xor cx,cx
    xor dx,dx
    mov dx,59
    mov cx,297
    mov ah,0dh
    int 10h
    cmp al,09h
    je sesh1
    cmp al,04h
    je sesh1
    cmp al,0eh
    je sesh1
    
   
    sesh: RET
   
    sesh1:
   
    
   mov ah,0bh
   mov bh,1
   mov bl,13
   int 10h
   mov seshs,23
   RET
     
   
gameover endp
End main
