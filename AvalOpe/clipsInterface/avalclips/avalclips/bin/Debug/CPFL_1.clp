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
(printout t "  O DJ da subestação desligou? S|N : ")
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
  (printout t "  O Operador indicou a inspeção trecho a trecho a partir da Subestação ou a jusante do religador? SE|JUSANTE : ")
  (assert (Operador (Inspecao_trecho_a_trecho (read))))) 

(defrule MAIN::Regra3
   (Subestacao (Disjuntor_desligou S|SIM))
   (Alimentador (Religador_ativo_tronco N|NAO))
   =>
  (printout t "  O Operador indicou a inspeção trecho a trecho a partir da Subestação? S|N : ")
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
   (printout t "  A recomendação quando há atuação do DJ da SE e quando não há religador ativo no tronco
 é proceder a inspeção trecho a trecho, a partir da Subestação." crlf)
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
   (printout t "  A recomendação quando há atuação do DJ da SE e quando não há desligamento do religador do tronco
 é proceder a inspeção trecho a trecho, a partir da Subestação." crlf)
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
  (printout t "  Ocorrendo desligamento simultâneo de dois dispositivos de proteção consecutivos, o defeito sempre estará 
a jusante do dispositivo mais distante da Subestação, tendo havido descoordenação ou falha de proteção." crlf)
  (printout t " " crlf))

(defrule MAIN::Regra7
   (Subestacao (Disjuntor_desligou S|SIM))
   (Alimentador (Religador_desligou N|NAO))
   (Operador (Inspecao_trecho_a_trecho SE))
   =>
   (assert (Operador (Acao_correta SIM)))
   (printout t " " crlf)   
   (printout t "  AÇÃO CORRETA DO OPERADOR " crlf)
   (printout t "  O defeito sempre estará entre dois dispostivos de proteção consecutivos, tendo o primeiro atuado e o segundo não." crlf)
   (printout t " " crlf))

(defrule MAIN::Regra8
   (Subestacao (Disjuntor_desligou S|SIM))
   (Alimentador (Religador_desligou S|SIM))
   (Operador (Inspecao_trecho_a_trecho JUSANTE))
   =>
   (assert (Operador (Acao_correta SIM)))   
   (printout t " " crlf)
   (printout t "  AÇÃO CORRETA DO OPERADOR" crlf)
   (printout t "  Ocorrendo desligamento simultâneo de dois dispositivos de proteção consecutivos, o defeito sempre estará 
   a jusante do dispositivo mais distante da Subestação, tendo havido descoordenação ou falha de proteção." crlf)
   (printout t " " crlf))

(defrule MAIN::Regra9
  (Subestacao (Disjuntor_desligou N|NAO))
  (Alimentador (Religador_desligou S|SIM))
  (Operador (Inspecao_trecho_a_trecho JUSANTE))
=>
  (assert (Operador (Acao_correta SIM)))
  (printout t " " crlf)
  (printout t "  AÇÃO CORRETA DO OPERADOR:  " crlf)
  (printout t "  A recomendação quando o DJ da SE não atuou e religador do tronco do alimentador abriu, é proceder a inspeção trecho a trecho, a partir do religador." crlf)
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
  (printout t "  A recomendação quando o DJ da SE não atuou e o religador do tronco do alimentador abriu, é proceder a inspeção trecho a trecho, a partir do religador." crlf)
  (printout t " " crlf))

(defrule MAIN::Regra11
  (Subestacao (Disjuntor_desligou N|NAO))
  (or (Alimentador (Religador_ativo_tronco N|NAO))
       (and (Alimentador (Religador_ativo_tronco S|SIM))
            (Alimentador (Religador_desligou N|NAO))))
=>
 (printout t "  Alguma proteção atuou no tronco do alimentador? S|N : ")
 (assert (Alimentador (Protecao_atuou (read))))
 (printout t "  Indicar qual proteção atuou : ")
 (assert (Alimentador (Nome_protecao_atuou (read)))))

(defrule MAIN::Regra12
  (Subestacao (Disjuntor_desligou N|NAO))
  (or (Alimentador (Religador_ativo_tronco N|NAO))
       (and (Alimentador (Religador_ativo_tronco S|SIM))
            (Alimentador (Religador_desligou N|NAO))))
  (Alimentador (Protecao_atuou S|SIM))
  (Alimentador (Nome_protecao_atuou ?Nome& ~nil)) 
=>
 (printout t "  O operador indicou a inspeção a partir do dispositivo de proteção " ?Nome "? S|N : ")
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
  (printout t "  O operador deveria ter indicado a inspeção trecho a trecho, a partir do dipositivo de proteção " ?Nome "."  crlf)
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
  (printout t "  AÇÃO CORRETA DO OPERADOR:  " crlf)
  (printout t "  A recomendação é proceder a inspeção trecho a trecho a partir do dispositivo de proteção que atuou, no caso o dispositio " ?Nome "." crlf)
  (printout t " " crlf))

;
; REGRAS ENVOLVENDO CHAVES FUSÍVEIS
;

(defrule MAIN::Regra15
   (Subestacao (Disjuntor_desligou S|SIM))
   (Operador (Acao_correta S|SIM|N|NAO))
   =>
  (printout t "  O Operador inspecionou ramais que derivam de chaves fusíveis?? : ")
  (assert (Alimentador (Ramal_chave_fusivel (read)))))

(defrule MAIN::Regra16
   (or (Operador (Inspecao_trecho_a_trecho SE))
       (Operador (Inspecao_trecho_a_trecho JUSANTE))
       (Operador (Inspecao_trecho_a_trecho_SE S|N)))
   (Alimentador (Ramal_chave_fusivel S|SIM))
   =>
  (printout t "  A chave fusível tinha o elo queimado?? : ")
  (assert (Alimentador (Chave_fusivel_elo_queimado (read))))
  (printout t "  A inspeção foi finalizada?? : ")
  (assert (Operador (Inspecao_finalizada (read))))
  (printout t "  A tentativa de religamento deu certo?? : ")
  (assert (Alimentador (Religamento_deu_certo (read)))))  
  
(defrule MAIN::Regra17
  (Alimentador (Ramal_chave_fusivel S|SIM))
  (Alimentador (Chave_fusivel_elo_queimado S|SIM))
   =>
  (printout t " " crlf)
  (printout t "  AÇÃO CORRETA DO OPERADOR" crlf)
  (printout t "  Se a proteção do ramal atuou, o ramal deve ser inspecionado." crlf)
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
  (printout t "  AÇÃO CORRETA DO OPERADOR" crlf)
  (printout t "  Depois de realizada a inspeção trecho a trecho e não havendo sucesso na tentativa de religamento,
os ramais protegidos por elos fusíveis não queimados também devem ser inspecionados." crlf)
  (printout t " " crlf))
  
(defrule MAIN::Regra19
  (Alimentador (Ramal_chave_fusivel S|SIM))
  (Alimentador (Chave_fusivel_elo_queimado N|NAO))
  (Alimentador (Religamento_deu_certo S|SIM)) 
   =>
  (printout t " " crlf)
  (printout t "  ERRO operador: " crlf)
  (printout t "  Os ramais que derivam de dispositivos de proteção não precisam ser inspecioanados se não
há elos queimados." crlf)
  (printout t " " crlf))




