<?php
// process client request (via URL)
	header ("Content-Type_application/json");
	$funzione=$_GET['funzione'];
	switch($funzione)
	{
		case '0':
			$dati=datiConversione('libri.json');
			$arr=array();
			
			$i=0;
			
			
			foreach ($dati['libri'] as $libro)
			{
				
				$arr[$i] =$libro['titolo'];
				$i=$i+1;
			}
			deliver_response(200,"catalogo", $arr);
		break;
		case '1':
			//Conversioni file JSON in array associativi
			$dati = datiConversione('libri.json');
			$reparti = datiConversione('reparti.json');

			//inizializzazione variabili
			$arr = array();

			$i = 0;
			$idFumetti="";
			
			foreach($reparti['reparti'] as $rep)
			{
				if(strtoupper($rep['tipo']) == strtoupper('Fumetti'))
				{
					$idFumetti=$rep['id'];
				}
			}

		
			foreach($dati['libri'] as $libro)
			{
				if($libro['reparto'] == $idFumetti && strtoupper($libro['categoria']) == strtoupper('I più venduti'))
				{
					$arr[$i] = $libro['titolo'];
					$i = $i + 1;
				}
			}
		
			deliver_response(200,"fumetti ", $arr);		
			
		break;
		case '2':
		    //Conversioni file JSON in array associativi
			$dati = datiConversione('libri.json');
			$categorie = datiConversione('categorie.json');
			$libriCategoria = datiConversione('libriCategoria.json');

			 //inizializzazione variabili
			$tit=array();
			$arr=array();
			

			$i=0;
			

			foreach($categorie['categorie'] as $cat)
			{
				if($cat['sconto'] != 0 )
				{
					foreach($libriCategoria['libriCategoria'] as $libCat)
					{
						if($libCat['categoria'] == $cat['tipo'] )
						{
							foreach($dati['libri'] as $libro)
							{
								if($libro['id']==$libCat['libro'])
								{
									array_push($arr,array('sconto'=>$cat['sconto'],"titolo"=>$libro["titolo"]));
								}
							}

						}
					}
				}
			}
			asort($arr);		
			
			foreach($arr as $libro)
			{
				array_push($tit,$libro['titolo']);
			}
			deliver_response(200,"sconti  ", $tit);		
						
		break;
		case '3':			

			//Conversione file JSON in array associativo
            $dati = datiConversione('libri.json');

            //inizializzazione variabili
			$arr = array();
			
			//spit per dividere le date inserite da input in giorno mese e anno
			$tmpInizio = explode('/',$_GET['data1']);
			$tmpFIne = explode('/',$_GET['data2']);
			
			//Per la ricerca dei libri tra due date utilizziamo il timestamp delle date inserite e della data di inserimento del libro            
            //L'mktime calcola in secondi il tempo trascorso dal 1 gennaio 1970 

            //Timestamp data inizio ricerca (mese,giorno,anno)
            $dataI = mktime(0,0,0,$tmpInizio[1],$tmpInizio[0],$tmpInizio[2]);

            //Timestamp data inizio ricerca (mese,giorno,anno)
			$dataF = mktime(0,0,0,$tmpFIne[1],$tmpFIne[0],$tmpFIne[2]);
			
			
           
            foreach($dati['libri'] as $libro)
            {
                $tmp = explode("/", $libro['dataArch']);
                $dataArch = mktime(0,0,0,$tmp[1], $tmp[0], $tmp[2]);

				if($dataArch <= $dataF && $dataArch >= $dataI)
				{
					array_push($arr, $libro['titolo']);
				}
            }
            
            deliver_response(200,"date    ", $arr);    
		break;
		case '4':
		 	//Conversione file JSON in array associativo
			$dati = datiConversione('libri.json');
            $user = datiConversione('utenti.json');
            $carrelli = datiConversione('carrelli.json');
            $libriCarr = datiConversione('libriCarrello.json');
			
            $idCarrello = $_GET['idCarrello'];
            $utente="";
            $tit = array();
            $nCopie = "";

            foreach($carrelli['carrelli'] as $carr)
            {
                if($idCarrello ==  $carr["id"])
                    $utente = $carr["utente"];
            }

            foreach($libriCarr['libriCarrello'] as $associazione)
            {
                
				foreach($dati['libri'] as $libro)
				{
					if(($libro['id'] == $associazione['libro'])&&($associazione['carrello'] == $idCarrello))
						array_push($tit, array('titolo'=>$libro['titolo'], 'nCopie' => $associazione['nCopie']));
				}

				$nCopie = $associazione['nCopie'];
                
            }

            
            $arr = array();
            array_push($arr, array('utente'=>$utente, 'libri' => $tit));

            deliver_response(200,"carrello", $arr);

		break;
		/*default:
			deliver_response(400,"Invalid request", NULL);
		break;*/

        
	}
	
	//funzione per l'invio di messaggi al client
	function deliver_response($status, $status_message, $data)
	{
		header("HTTP/1.1 $status $status_message");
		
		$response ['status']=$status;
		$response['status_message']=$status_message;
		$response['data']=$data;
		
		$json_response=json_encode($response);
		echo $json_response;
	}

	//funzione per convertre file json ad array associativo
	function datiConversione($json)
	{
		$str = file_get_contents($json);
		$dati = json_decode($str, true); 

		return $dati;
	}
	

?>