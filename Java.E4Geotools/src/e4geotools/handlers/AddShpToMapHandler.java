package e4geotools.handlers;

import javax.inject.Inject;

import org.eclipse.e4.core.di.annotations.Execute;
import org.eclipse.e4.core.services.events.IEventBroker;

public class AddShpToMapHandler {
	@Inject
	private IEventBroker eventBroker;

	@Execute
	public void addShpFile() {
		eventBroker.send("e4geotools/addShpFileEventTopic", null);
	}
}
