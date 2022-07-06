(deftemplate Subestacao
   (slot Disjuntor_desligou)
   (slot Disjuntor_com_defeito))

(deftemplate Operador
   (slot Inspecao_trecho_a_trecho)
   (slot Inspecao_trecho_a_trecho_religador)
   (slot Inspecao_trecho_a_trecho_SE)
   (slot Encontrou_defeito)
   (slot Inspecao_finalizada)
   (slot Indicou_inspecao)
   (slot Erro_tipo)
   (slot Acao_correta))

(deftemplate Alimentador
   (slot Religador_ativo_tronco)
   (slot Religador_desligou)
   (slot Religamento_deu_certo)
   (slot Ramal_chave_fusivel)
   (slot Chave_fusivel_elo_queimado)
   (slot Religador_defeito)
   (slot Protecao_atuou)
   (slot Nome_protecao_atuou))
;
; REGRA INICIAL
;
(defrule inicial
=>
(printout t "  O DJ da subesta��o desligou? S|N : ")
(assert (Subestacao (Disjuntor_desligou (read)))))

;
; REGRAS ENVOLVENDO DJ DA SE
;
(defrule MAIN::regra1
   (or (Subestacao (Disjuntor_desligou S|SIM))
       (Subestacao (Disjuntor_desligou N|NAO)))
   =>
   (printout t "  O alimentador possui religador ativo no tronco? S|N : ")
   (assert (Alimentador (Religador_ativo_tronco (read)))))

(defrule MAIN::Regra2
   (Alimentador (Religador_ativo_tronco S|SIM))
   =>
  (printout t "  O religador do tronco desligou? S|N : ")
  (assert (Alimentador (Religador_desligou (read))))
  (printout t "  O Operador indicou a inspe��o trecho a trecho a partir da Subesta��o ou a jusante do religador? SE|JUSANTE : ")
  (assert (Operador (Inspecao_trecho_a_trecho (read))))) 

(defrule MAIN::Regra3
   (Subestacao (Disjuntor_desligou S|SIM))
   (Alimentador (Religador_ativo_tronco N|NAO))
   =>
  (printout t "  O Operador indicou a inspe��o trecho a trecho a partir da Subesta��o? S|N : ")
  (assert (Operador (Inspecao_trecho_a_trecho_SE (read)))))

(defrule MAIN::Regra4
   (Subestacao (Disjuntor_desligou S|SIM))
   (Alimentador (Religador_ativo_tronco N|NAO))
   (Operador (Inspecao_trecho_a_trecho_SE N|NAO))
   =>
   (assert (Operador (Erro_tipo 6)))
   (assert (Operador (Acao_correta NAO)))
   (printout t " " crlf)
   (printout t "  ERRO operador:  " crlf)
   (printout t "  A recomenda��o quando h� atua��o do DJ da SE e quando n�o h� religador ativo no tronco
 � proceder a inspe��o trecho a trecho, a partir da Subesta��o." crlf)
   (printout t " " crlf))

(defrule MAIN::Regra5
   (Subestacao (Disjuntor_desligou S|SIM))
   (Alimentador (Religador_desligou N|NAO))
   (Operador (Inspecao_trecho_a_trecho JUSANTE))
   =>
   (assert (Operador (Erro_tipo 6)))
   (assert (Operador (Acao_correta NAO)))
   (printout t " " crlf)
   (printout t "  ERRO operador:  " crlf)
   (printout t "  A recomenda��o quando h� atua��o do DJ da SE e quando n�o h� desligamento do religador do tronco
 � proceder a inspe��o trecho a trecho, a partir da Subesta��o." crlf)
   (printout t " " crlf))
   
(defrule MAIN::Regra6
   (Subestacao (Disjuntor_desligou S|SIM))
   (Alimentador (Religador_desligou S|SIM))
   (Operador (Inspecao_trecho_a_trecho SE))
   =>
  (assert (Operador (Erro_tipo 6)))
  (assert (Operador (Acao_correta NAO)))
  (printout t " " crlf)
  (printout t "  ERRO operador: " crlf)
  (printout t "  Ocorrendo desligamento simult�neo de dois dispositivos de prote��o consecutivos, o defeito sempre estar� 
a jusante do dispositivo mais distante da Subesta��o, tendo havido descoordena��o ou falha de prote��o." crlf)
  (printout t " " crlf))

(defrule MAIN::Regra7
   (Subestacao (Disjuntor_desligou S|SIM))
   (Alimentador (Religador_desligou N|NAO))
   (Operador (Inspecao_trecho_a_trecho SE))
   =>
   (assert (Operador (Acao_correta SIM)))
   (printout t " " crlf)   
   (printout t "  A��O CORRETA DO OPERADOR " crlf)
   (printout t "  O defeito sempre estar� entre dois dispostivos de prote��o consecutivos, tendo o primeiro atuado e o segundo n�o." crlf)
   (printout t " " crlf))

(defrule MAIN::Regra8
   (Subestacao (Disjuntor_desligou S|SIM))
   (Alimentador (Religador_desligou S|SIM))
   (Operador (Inspecao_trecho_a_trecho JUSANTE))
   =>
   (assert (Operador (Acao_correta SIM)))   
   (printout t " " crlf)
   (printout t "  A��O CORRETA DO OPERADOR" crlf)
   (printout t "  Ocorrendo desligamento simult�neo de dois dispositivos de prote��o consecutivos, o defeito sempre estar� 
   a jusante do dispositivo mais distante da Subesta��o, tendo havido descoordena��o ou falha de prote��o." crlf)
   (printout t " " crlf))

(defrule MAIN::Regra9
  (Subestacao (Disjuntor_desligou N|NAO))
  (Alimentador (Religador_desligou S|SIM))
  (Operador (Inspecao_trecho_a_trecho JUSANTE))
=>
  (assert (Operador (Acao_correta SIM)))
  (printout t " " crlf)
  (printout t "  A��O CORRETA DO OPERADOR:  " crlf)
  (printout t "  A recomenda��o quando o DJ da SE n�o atuou e religador do tronco do alimentador abriu, � proceder a inspe��o trecho a trecho, a partir do religador." crlf)
  (printout t " " crlf))

(defrule MAIN::Regra10
  (Subestacao (Disjuntor_desligou N|NAO))
  (Alimentador (Religador_desligou S|SIM))
  (Operador (Inspecao_trecho_a_trecho SE))
=>
  (assert (Operador (Erro_tipo 6)))
  (assert (Operador (Acao_correta NAO)))
  (printout t " " crlf)
  (printout t "  ERRO DO OPERADOR:  " crlf)
  (printout t "  A recomenda��o quando o DJ da SE n�o atuou e o religador do tronco do alimentador abriu, � proceder a inspe��o trecho a trecho, a partir do religador." crlf)
  (printout t " " crlf))

(defrule MAIN::Regra11
  (Subestacao (Disjuntor_desligou N|NAO))
  (or (Alimentador (Religador_ativo_tronco N|NAO))
       (and (Alimentador (Religador_ativo_tronco S|SIM))
            (Alimentador (Religador_desligou N|NAO))))
=>
 (printout t "  Alguma prote��o atuou no tronco do alimentador? S|N : ")
 (assert (Alimentador (Protecao_atuou (read))))
 (printout t "  Indicar qual prote��o atuou : ")
 (assert (Alimentador (Nome_protecao_atuou (read)))))

(defrule MAIN::Regra12
  (Subestacao (Disjuntor_desligou N|NAO))
  (or (Alimentador (Religador_ativo_tronco N|NAO))
       (and (Alimentador (Religador_ativo_tronco S|SIM))
            (Alimentador (Religador_desligou N|NAO))))
  (Alimentador (Protecao_atuou S|SIM))
  (Alimentador (Nome_protecao_atuou ?Nome& ~nil)) 
=>
 (printout t "  O operador indicou a inspe��o a partir do dispositivo de prote��o " ?Nome "? S|N : ")
 (assert(Operador (Indicou_inspecao (read)))))
 
(defrule MAIN::Regra13
  (Subestacao (Disjuntor_desligou N|NAO))
  (or (Alimentador (Religador_ativo_tronco N|NAO))
       (and (Alimentador (Religador_ativo_tronco S|SIM))
            (Alimentador (Religador_desligou N|NAO))))
  (Alimentador (Protecao_atuou S|SIM))
  (Operador (Indicou_inspecao N|NAO))
  (Alimentador (Nome_protecao_atuou ?Nome& ~nil)) 
=>
  (assert (Operador (Erro_tipo 6)))
  (assert (Operador (Acao_correta NAO)))
  (printout t " " crlf)
  (printout t "  ERRO DO OPERADOR:  " crlf)
  (printout t "  O operador deveria ter indicado a inspe��o trecho a trecho, a partir do dipositivo de prote��o " ?Nome "."  crlf)
  (printout t " " crlf))

(defrule MAIN::Regra14
  (Subestacao (Disjuntor_desligou N|NAO))
  (or (Alimentador (Religador_ativo_tronco N|NAO))
       (and (Alimentador (Religador_ativo_tronco S|SIM))
            (Alimentador (Religador_desligou N|NAO))))
  (Alimentador (Protecao_atuou S|SIM))
  (Operador (Indicou_inspecao S|SIM))
  (Alimentador (Nome_protecao_atuou ?Nome& ~nil)) 
=>
  (assert (Operador (Acao_correta SIM)))
  (printout t " " crlf)
  (printout t "  A��O CORRETA DO OPERADOR:  " crlf)
  (printout t "  A recomenda��o � proceder a inspe��o trecho a trecho a partir do dispositivo de prote��o que atuou, no caso o dispositio " ?Nome "." crlf)
  (printout t " " crlf))

;
; REGRAS ENVOLVENDO CHAVES FUS�VEIS
;

(defrule MAIN::Regra15
   (Subestacao (Disjuntor_desligou S|SIM))
   (Operador (Acao_correta S|SIM|N|NAO))
   =>
  (printout t "  O Operador inspecionou ramais que derivam de chaves fus�veis?? : ")
  (assert (Alimentador (Ramal_chave_fusivel (read)))))

(defrule MAIN::Regra16
   (or (Operador (Inspecao_trecho_a_trecho SE))
       (Operador (Inspecao_trecho_a_trecho JUSANTE))
       (Operador (Inspecao_trecho_a_trecho_SE S|N)))
   (Alimentador (Ramal_chave_fusivel S|SIM))
   =>
  (printout t "  A chave fus�vel tinha o elo queimado?? : ")
  (assert (Alimentador (Chave_fusivel_elo_queimado (read))))
  (printout t "  A inspe��o foi finalizada?? : ")
  (assert (Operador (Inspecao_finalizada (read))))
  (printout t "  A tentativa de religamento deu certo?? : ")
  (assert (Alimentador (Religamento_deu_certo (read)))))  
  
(defrule MAIN::Regra17
  (Alimentador (Ramal_chave_fusivel S|SIM))
  (Alimentador (Chave_fusivel_elo_queimado S|SIM))
   =>
  (printout t " " crlf)
  (printout t "  A��O CORRETA DO OPERADOR" crlf)
  (printout t "  Se a prote��o do ramal atuou, o ramal deve ser inspecionado." crlf)
  (printout t " " crlf)
  (printout t "  O Operador identificou defeito entre o DJ e o religador ou a jusante do religador?? : ")
  (assert (Operador (Inspecao_trecho_a_trecho (read))))) 

(defrule MAIN::Regra18
  (Alimentador (Ramal_chave_fusivel S|SIM))
  (Alimentador (Chave_fusivel_elo_queimado N|NAO))
  (Operador (Inspecao_finalizada S|SIM))
  (Alimentador (Religamento_deu_certo N|NAO)) 
   =>
  (printout t " " crlf)
  (printout t "  A��O CORRETA DO OPERADOR" crlf)
  (printout t "  Depois de realizada a inspe��o trecho a trecho e n�o havendo sucesso na tentativa de religamento,
os ramais protegidos por elos fus�veis n�o queimados tamb�m devem ser inspecionados." crlf)
  (printout t " " crlf))
  
(defrule MAIN::Regra19
  (Alimentador (Ramal_chave_fusivel S|SIM))
  (Alimentador (Chave_fusivel_elo_queimado N|NAO))
  (Alimentador (Religamento_deu_certo S|SIM)) 
   =>
  (printout t " " crlf)
  (printout t "  ERRO operador: " crlf)
  (printout t "  Os ramais que derivam de dispositivos de prote��o n�o precisam ser inspecioanados se n�o
h� elos queimados." crlf)
  (printout t " " crlf))




