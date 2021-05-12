class Carrinho {

    clickIncremento(button) {
        //this -  instancia atual da classe.
        let data = this.getData(button);
        data.Quantidade++;

        this.postQuantidade(data);
    }

    clickDecremento(button) {
        //this -  instancia atual da classe.
        let data = this.getData(button);
        data.Quantidade--;
        this.postQuantidade(data);
    }

    //Essa função vai ser acionado para mudar a quantidade que aparece na caixa de texto após decrementar ou incrementar
    updateQuantidade(input) {
        let data = this.getData(input);
        this.postQuantidade(data);
    }

    getData(elemento) {
        var linhaDoItem = $(elemento).parents('[item-id]'); //pegou a linha da div que contém esse botão
        var itemId = $(linhaDoItem).attr('item-id'); //pegou o valor do atributo item-id nessa linha
        var novaQuantidade = $(linhaDoItem).find('input').val(); //pegou o valor da quantidade a partir do primeiro input após essa linha item

        //Parents obtém ancestrais do elemento e find obtém os elementos abaixo da hierarquia.

        var data = {
            Id: itemId,
            Quantidade: novaQuantidade
        };

        return data;
    }

    postQuantidade(data) {
        
        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        //ajax faz requisição assincrona ao servidor.
        //done é executado somente quando o servidor devolve a resposta a requisição Ajax
        $.ajax({
            url: '/pedido/updatequantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done((response) => {
            let itemPedido = response.itemPedido;

            let linhaDoItem = $('[item-id=' + itemPedido.id + ']');
            linhaDoItem.find('input').val(itemPedido.quantidade);
            linhaDoItem.find('[subtotal]').html((itemPedido.subtotal).duasCasas());

            let carrinhoViewModel = response.carrinhoViewModel;
            $('[numero-itens]').html('Total: ' + carrinhoViewModel.itens.length + ' itens');
            $('[total]').html(carrinhoViewModel.total.duasCasas());


            if (itemPedido.quantidade == 0) {
                linhaDoItem.remove();
            }

        });
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}