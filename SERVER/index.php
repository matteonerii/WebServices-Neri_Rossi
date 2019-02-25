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
			
			//Per la ricerca dei libri tra due date utilizziamo il timestamp delle date inserite e della data di inserimento del libro            
            //L'mktime calcola in secondi il tempo trascorso dal 1 gennaio 1970 

            //Timestamp data inizio ricerca
            $dataI = mktime(0,0,0,$_GET['mese1'],$_GET['giorno1'],$_GET['anno1']);

            //Timestamp data inizio ricerca
			$dataF = mktime(0,0,0,$_GET['mese2'],$_GET['giorno2'],$_GET['anno2']);
			
			
           
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
			
		break;
	}
	

	function deliver_response($status, $status_message, $data)
	{
		header("HTTP/1.1 $status $status_message");
		
		$response ['status']=$status;
		$response['status_message']=$status_message;
		$response['data']=$data;
		
		$json_response=json_encode($response);
		echo $json_response;
	}
	function datiConversione($json)
	{
		$str = file_get_contents($json);
		$dati = json_decode($str, true); 

		return $dati;
	}
	function get_price($find)
	{
		$books=datiConversione('libri.json');
		 foreach($books['book'] as $book)
		 {
			 if($book['name']==$find)
			 {
				 return $book['price'];
				 break;
			 }
		 }
    }

?>