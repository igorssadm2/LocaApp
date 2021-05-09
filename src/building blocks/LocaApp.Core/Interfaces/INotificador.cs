using LocaApp.FrameWork.Notificacoes;
using System.Collections.Generic;


namespace LocaApp.FrameWork.Interfaces
{
	public interface INotificador
	{
		bool TemNotificacao();
		List<Notificacao> ObterNotificacoes();
		void Handle(Notificacao notificacao);
	}
}
