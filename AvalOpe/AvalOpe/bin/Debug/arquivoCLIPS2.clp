(deftemplate example
 (slot w
   (type INTEGER)
   (default 9)
 )
)

(deftemplate MAIN::r_seguranca
   (slot r)
)

(deftemplate MAIN::r_custo
   (slot r)
)

(deftemplate MAIN::r_servico
   (slot r)
)

(deftemplate MAIN::r_produto
   (slot r)
)

(deftemplate MAIN::seguranca
   (slot fio_partido)
   (slot sequencia_chaves)
   (slot num_chaves))

   
(deftemplate MAIN::custo
   (slot tempo_execucao_manut)
   (slot tempo_extra)
   (slot perda_receita))

(deftemplate MAIN::servico
   (slot DMIC)
   (slot consumidor_prioritario))

(deftemplate MAIN::produto
   (slot tensao))

(defrule MAIN::rule_seguranca
   ?f <- (seguranca (fio_partido S))
   =>
   (assert (r_seguranca (r "Fazer manutenção da Linha indicada")))
   )

(defrule MAIN::rule_custo
   (custo (tempo_execucao_manut ?tempo))
   (test(> ?tempo 18))
   =>
   (assert (r_custo (r "Considerar também o cálculo do DMIC para consumidor não prioritário")))
   )

(defrule MAIN::rule_servico
   (servico (consumidor_prioritario S))
   =>
   (assert (r_servico (r "Considerar o cálculo do DMIC para consumidor prioritário")))
   )

;(defrule MAIN::rule_produto
;   (produto (tensao S))
;   =>
;   (assert (r_produto (r "Verificar qual a mensagem correta")))
;   )
 
;(defrule entrada_fatos
;=>
;(printout t " A contingência gerou algum fio partido? (S/N) : ")
;(assert (seguranca (fio_partido S)))
;(printout t " Algum consumidor prioritário ficou sem energia? (S/N) : ")
;(assert (servico (consumidor_prioritario S)))
;(printout t " Qual o tempo total da manutenção? (horas) : ")
;(assert (custo (tempo_execucao_manut 20)))
;(printout t " Alguma barra ficou com tensão abaixo de 0,95 pu? (S/N) : ")
;(assert (produto (tensao S))))


;(deffunction MAIN::get-seguranca ()
;  (find-all-facts ((?f seguranca)) TRUE)
;)

;(deffunction MAIN::get-custo ()
;  (find-all-facts ((?f custo)) TRUE)
;)

;(deffunction MAIN::get-servico ()
;  (find-all-facts ((?f servico)) TRUE)
;)

;(deffunction MAIN::get-produto ()
;  (find-all-facts ((?f produto)) TRUE)
;)

(deffunction MAIN::get-resposta-seguranca ()
  (find-all-facts ((?f r_seguranca)) TRUE)
)

(deffunction MAIN::get-resposta-custo ()
  (find-all-facts ((?f r_custo)) TRUE)
)

(deffunction MAIN::get-resposta-servico ()
  (find-all-facts ((?f r_servico)) TRUE)
)

(deffunction MAIN::get-resposta-produto ()
  (find-all-facts ((?f r_produto)) TRUE)
)